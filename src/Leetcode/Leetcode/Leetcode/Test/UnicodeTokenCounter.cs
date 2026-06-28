using System.Buffers;
using System.Globalization;
using System.Text;
using System.Text.Json;
using Leetcode.Test.Models;
using Leetcode.Test.Models.Content;

namespace Leetcode.Test;

/// <summary>
/// Provides TokenGuard's default heuristic <see cref="ITokenCounter"/> implementation.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="EstimatedTokenCounter"/> is used internally by TokenGuard's built-in configuration and factory paths.
/// It stays dependency-free while producing estimates that are more stable for prose, code, JSON, punctuation, mixed
/// Unicode text, and tool payloads than a plain character-count heuristic.
/// </para>
/// <para>
/// The implementation uses Unicode-aware scanning, lightweight content-shape detection, and structural accounting for
/// JSON and tool segments. It intentionally does not load provider vocabularies or perform BPE merges.
/// </para>
/// <para>
/// Each counted <see cref="ContextMessage"/> includes a fixed framing overhead, and tool-call segments add structural
/// wrapper cost so TokenGuard budgets remain closer to real chat payload costs than segment-only counting would
/// provide. Applications that require different creation flows can bypass dependency injection and construct
/// <see cref="ConversationContextFactory"/> directly, but the built-in factory path always uses this heuristic counter.
/// </para>
/// </remarks>
internal sealed class UnicodeTokenCounter
{
    private const int MessageOverhead = 4;
    private const int ToolEnvelopeOverhead = 6;
    private const int ToolFieldOverhead = 1;
    private const int JsonObjectOverhead = 1;
    private const int JsonArrayOverhead = 1;
    private const int JsonStringOverhead = 1;

    /// <inheritdoc />
    public int Count(ContextMessage contextMessage)
    {
        ArgumentNullException.ThrowIfNull(contextMessage);

        if (contextMessage.TokenCount is > 0)
        {
            return contextMessage.TokenCount.Value;
        }

        var total = MessageOverhead;

        foreach (var segment in contextMessage.Segments)
        {
            total += CountSegment(segment);
        }

        return total;
    }

    /// <inheritdoc />
    public int Count(IEnumerable<ContextMessage> messages)
    {
        ArgumentNullException.ThrowIfNull(messages);

        return messages.Sum(this.Count);
    }

    private static int CountSegment(ContentSegment segment) =>
        segment switch
        {
            TextContent text => CountText(text.Content),
            ToolUseContent toolUse => CountToolEnvelope(
                new ToolField(toolUse.ToolCallId, IsStructured: false),
                new ToolField(toolUse.ToolName, IsStructured: false),
                new ToolField(toolUse.Content, IsStructured: true)),
            ToolResultContent toolResult => CountToolEnvelope(
                new ToolField(toolResult.ToolCallId, IsStructured: false),
                new ToolField(toolResult.ToolName, IsStructured: false),
                new ToolField(toolResult.Content, IsStructured: LooksLikeJson(toolResult.Content.AsSpan().Trim()))),
            _ => CountText(segment.Content)
        };

    private static int CountToolEnvelope(params ToolField[] fields)
    {
        var total = ToolEnvelopeOverhead;

        foreach (var field in fields)
        {
            total += ToolFieldOverhead;
            total += field.IsStructured ? CountStructuredPayload(field.Value) : CountQuotedString(field.Value);
        }

        return total;
    }

    private static int CountText(string? text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return 0;
        }

        var trimmed = text.AsSpan().Trim();
        if (LooksLikeJson(trimmed) && TryCountJson(trimmed.ToString(), out var jsonCount))
        {
            return Math.Max(1, jsonCount);
        }

        return Math.Max(1, CountGeneralText(text));
    }

    private static int CountStructuredPayload(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return 0;
        }

        var trimmed = text.AsSpan().Trim();
        if (LooksLikeJson(trimmed) && TryCountJson(trimmed.ToString(), out var jsonCount))
        {
            return Math.Max(1, jsonCount);
        }

        return CountQuotedString(text);
    }

    private static int CountQuotedString(string text) =>
        JsonStringOverhead + CountGeneralText(text) + CountEscapes(text);

    private static int CountEscapes(string text)
    {
        var escapeCount = 0;

        foreach (var c in text)
        {
            if (c is '"' or '\\' or '\n' or '\r' or '\t')
            {
                escapeCount++;
            }
        }

        return escapeCount == 0 ? 0 : Math.Max(1, CeilingDiv(escapeCount, 3));
    }

    private static int CountGeneralText(string text)
    {
        var count = 0;
        var start = 0;

        while (start < text.Length)
        {
            if (char.IsWhiteSpace(text[start]))
            {
                var end = start + 1;
                while (end < text.Length && char.IsWhiteSpace(text[end]))
                {
                    end++;
                }

                count += CountWhitespace(text.AsSpan(start, end - start));
                start = end;
                continue;
            }

            var chunkEnd = start + 1;
            while (chunkEnd < text.Length && !char.IsWhiteSpace(text[chunkEnd]))
            {
                chunkEnd++;
            }

            count += CountChunk(text.AsSpan(start, chunkEnd - start));
            start = chunkEnd;
        }

        return count;
    }

    private static int CountChunk(ReadOnlySpan<char> chunk)
    {
        if (chunk.IsEmpty)
        {
            return 0;
        }

        if (LooksLikeJson(chunk) && TryCountJson(chunk.ToString(), out var jsonCount))
        {
            return jsonCount;
        }

        if (LooksLikeUrl(chunk) || LooksLikePath(chunk))
        {
            return 1 + CountChunkCore(chunk);
        }

        return CountChunkCore(chunk);
    }

    private static int CountChunkCore(ReadOnlySpan<char> chunk)
    {
        var count = 0;
        var index = 0;

        while (index < chunk.Length)
        {
            var rune = ReadRune(chunk, index, out var consumed);

            if (IsWordRune(rune))
            {
                var end = index + consumed;

                while (end < chunk.Length)
                {
                    var next = ReadRune(chunk, end, out var nextConsumed);
                    if (IsWordRune(next))
                    {
                        end += nextConsumed;
                        continue;
                    }

                    if (IsConnectorApostrophe(chunk, end))
                    {
                        end++;
                        continue;
                    }

                    break;
                }

                count += CountWordLike(chunk[index..end]);
                index = end;
                continue;
            }

            if (Rune.IsDigit(rune))
            {
                var digitCount = 1;
                var end = index + consumed;

                while (end < chunk.Length)
                {
                    var next = ReadRune(chunk, end, out var nextConsumed);
                    if (!Rune.IsDigit(next))
                    {
                        break;
                    }

                    digitCount++;
                    end += nextConsumed;
                }

                count += CeilingDiv(digitCount, 3);
                index = end;
                continue;
            }

            var punctuationEnd = index + consumed;
            while (punctuationEnd < chunk.Length)
            {
                var next = ReadRune(chunk, punctuationEnd, out var nextConsumed);
                if (IsWordRune(next) || Rune.IsDigit(next))
                {
                    break;
                }

                punctuationEnd += nextConsumed;
            }

            count += CountPunctuationOrSymbol(chunk[index..punctuationEnd]);
            index = punctuationEnd;
        }

        return count;
    }

    private static int CountWordLike(ReadOnlySpan<char> piece)
    {
        var graphemeCount = CountTextElements(piece);
        if (graphemeCount == 0)
        {
            return 0;
        }

        return DetectScriptGroup(piece) switch
        {
            ScriptGroup.Latin => CountLatinWord(piece, graphemeCount),
            ScriptGroup.CyrillicOrGreek => Math.Max(1, CeilingDiv(graphemeCount, 3)),
            ScriptGroup.ArabicHebrew => Math.Max(1, CeilingDiv(graphemeCount, 2)),
            ScriptGroup.CjkOrKanaOrHangul => graphemeCount,
            ScriptGroup.Other => Math.Max(1, CeilingDiv(graphemeCount, 2)),
            _ => Math.Max(1, CeilingDiv(graphemeCount * 3, 2))
        };
    }

    private static int CountLatinWord(ReadOnlySpan<char> piece, int graphemeCount)
    {
        var chunked = graphemeCount <= 7 ? 1 : CeilingDiv(graphemeCount, 4);
        var components = CountLatinComponents(piece);

        return Math.Max(chunked, components);
    }

    private static int CountLatinComponents(ReadOnlySpan<char> piece)
    {
        if (piece.IsEmpty)
        {
            return 0;
        }

        var componentCount = 1;

        for (var index = 1; index < piece.Length; index++)
        {
            if (piece[index] is '\'' or '’')
            {
                if (index > 0 && index < piece.Length - 1 && char.IsLetter(piece[index - 1]) && char.IsLetter(piece[index + 1]))
                {
                    componentCount++;
                }

                continue;
            }

            if (!char.IsLetter(piece[index]))
            {
                continue;
            }

            var previous = piece[index - 1];
            if (char.IsLower(previous) && char.IsUpper(piece[index]))
            {
                componentCount++;
                continue;
            }

            if (char.IsUpper(previous) && char.IsUpper(piece[index]) && index < piece.Length - 1 && char.IsLower(piece[index + 1]))
            {
                componentCount++;
            }
        }

        return componentCount;
    }

    private static int CountWhitespace(ReadOnlySpan<char> piece)
    {
        var newlines = 0;
        var nonNewline = 0;

        foreach (var c in piece)
        {
            if (c is '\n' or '\r')
            {
                newlines++;
            }
            else
            {
                nonNewline++;
            }
        }

        if (newlines == 0 && nonNewline <= 1)
        {
            return 0;
        }

        if (nonNewline == 0)
        {
            return newlines;
        }

        return newlines + Math.Max(1, CeilingDiv(nonNewline, 4));
    }

    private static int CountPunctuationOrSymbol(ReadOnlySpan<char> piece)
    {
        if (piece.IsEmpty)
        {
            return 0;
        }

        if (ContainsEmoji(piece))
        {
            return CountEmojiClusters(piece);
        }

        var asciiOnly = true;
        foreach (var c in piece)
        {
            if (c > 127)
            {
                asciiOnly = false;
                break;
            }
        }

        if (asciiOnly)
        {
            return CountAsciiPunctuationOrSymbol(piece);
        }

        var graphemeCount = CountTextElements(piece);
        return Math.Max(1, CeilingDiv(graphemeCount * 3, 2));
    }

    private static int CountAsciiPunctuationOrSymbol(ReadOnlySpan<char> piece)
    {
        if (piece.Length == 1)
        {
            return 1;
        }

        if (AllSameChar(piece))
        {
            return Math.Max(1, CeilingDiv(piece.Length, 3));
        }

        if (ContainsStructuralAscii(piece))
        {
            return Math.Max(1, CeilingDiv(piece.Length * 3, 4));
        }

        return Math.Max(1, CeilingDiv(piece.Length, 2));
    }

    private static bool ContainsStructuralAscii(ReadOnlySpan<char> piece)
    {
        foreach (var c in piece)
        {
            if (c is '{' or '}' or '[' or ']' or '(' or ')' or ':' or ',' or ';' or '=' or '"' or '`')
            {
                return true;
            }
        }

        return false;
    }

    private static int CountEmojiClusters(ReadOnlySpan<char> piece)
    {
        var total = 0;
        var enumerator = StringInfo.GetTextElementEnumerator(piece.ToString());

        while (enumerator.MoveNext())
        {
            var cluster = enumerator.GetTextElement();
            total += IsComplexEmojiCluster(cluster) ? 3 : 2;
        }

        return Math.Max(1, total);
    }

    private static bool IsComplexEmojiCluster(string cluster)
    {
        var hasJoiner = false;
        var runeCount = 0;

        foreach (var rune in cluster.EnumerateRunes())
        {
            runeCount++;
            if (rune.Value is 0x200D or >= 0x1F3FB and <= 0x1F3FF)
            {
                hasJoiner = true;
            }
        }

        return hasJoiner || runeCount > 2;
    }

    private static int CountTextElements(ReadOnlySpan<char> text)
    {
        if (text.IsEmpty)
        {
            return 0;
        }

        var count = 0;
        var enumerator = StringInfo.GetTextElementEnumerator(text.ToString());

        while (enumerator.MoveNext())
        {
            count++;
        }

        return count;
    }

    private static bool TryCountJson(string text, out int count)
    {
        try
        {
            using var document = JsonDocument.Parse(text);
            count = CountJsonElement(document.RootElement);
            return true;
        }
        catch (JsonException)
        {
            count = 0;
            return false;
        }
    }

    private static int CountJsonElement(JsonElement element) =>
        element.ValueKind switch
        {
            JsonValueKind.Object => CountJsonObject(element),
            JsonValueKind.Array => CountJsonArray(element),
            JsonValueKind.String => CountQuotedString(element.GetString() ?? string.Empty),
            JsonValueKind.Number => Math.Max(1, 1 + CeilingDiv(CountDigitsInNumber(element.GetRawText()), 3)),
            JsonValueKind.True => 1,
            JsonValueKind.False => 1,
            JsonValueKind.Null => 1,
            _ => 1
        };

    private static int CountJsonObject(JsonElement element)
    {
        var total = JsonObjectOverhead;
        var propertyCount = 0;

        foreach (var property in element.EnumerateObject())
        {
            propertyCount++;
            total += ToolFieldOverhead;
            total += CountQuotedString(property.Name);
            total += CountJsonElement(property.Value);
        }

        if (propertyCount > 1)
        {
            total += propertyCount - 1;
        }

        return total;
    }

    private static int CountJsonArray(JsonElement element)
    {
        var total = JsonArrayOverhead;
        var itemCount = 0;

        foreach (var item in element.EnumerateArray())
        {
            itemCount++;
            total += CountJsonElement(item);
        }

        if (itemCount > 1)
        {
            total += Math.Max(1, CeilingDiv(itemCount - 1, 2));
        }

        return total;
    }

    private static int CountDigitsInNumber(string text)
    {
        var count = 0;

        foreach (var c in text)
        {
            if (char.IsDigit(c))
            {
                count++;
            }
        }

        return Math.Max(1, count);
    }

    private static bool LooksLikeJson(ReadOnlySpan<char> text)
    {
        if (text.Length < 2)
        {
            return false;
        }

        return (text[0], text[^1]) is ('{', '}') or ('[', ']');
    }

    private static bool LooksLikeUrl(ReadOnlySpan<char> text) =>
        text.Contains("://", StringComparison.Ordinal) || text.StartsWith("www.", StringComparison.OrdinalIgnoreCase);

    private static bool LooksLikePath(ReadOnlySpan<char> text)
    {
        if (text.Length < 2)
        {
            return false;
        }

        if (text.StartsWith("./", StringComparison.Ordinal) ||
            text.StartsWith("../", StringComparison.Ordinal) ||
            text.StartsWith("~/", StringComparison.Ordinal) ||
            text[0] == '/' ||
            text.Contains('\\'))
        {
            return true;
        }

        return text.Contains('/') && !text.Contains("://", StringComparison.Ordinal);
    }

    private static bool IsWordRune(Rune rune)
    {
        if (Rune.IsLetter(rune))
        {
            return true;
        }

        return Rune.GetUnicodeCategory(rune) is UnicodeCategory.NonSpacingMark
            or UnicodeCategory.SpacingCombiningMark
            or UnicodeCategory.EnclosingMark;
    }

    private static bool IsConnectorApostrophe(ReadOnlySpan<char> text, int index)
    {
        if (index <= 0 || index >= text.Length - 1)
        {
            return false;
        }

        var value = text[index];
        return value is '\'' or '’'
            && char.IsLetter(text[index - 1])
            && char.IsLetter(text[index + 1]);
    }

    private static Rune ReadRune(ReadOnlySpan<char> text, int index, out int charsConsumed)
    {
        var status = Rune.DecodeFromUtf16(text[index..], out var rune, out charsConsumed);
        if (status == OperationStatus.Done)
        {
            return rune;
        }

        charsConsumed = 1;
        return new Rune(text[index]);
    }

    private static bool ContainsEmoji(ReadOnlySpan<char> text)
    {
        var index = 0;

        while (index < text.Length)
        {
            var rune = ReadRune(text, index, out var consumed);
            if (IsEmojiRune(rune))
            {
                return true;
            }

            index += consumed;
        }

        return false;
    }

    private static bool IsEmojiRune(Rune rune) =>
        rune.Value is 0x00A9 or 0x00AE or 0x203C or 0x2049 or 0x2122 or 0x2139
        or 0x2194 or 0x2195 or 0x2196 or 0x2197 or 0x2198 or 0x2199
        or >= 0x231A and <= 0x231B
        or >= 0x23E9 and <= 0x23FA
        or >= 0x2460 and <= 0x24FF
        or >= 0x25AA and <= 0x27BF
        or >= 0x1F000 and <= 0x1FAFF;

    private static ScriptGroup DetectScriptGroup(ReadOnlySpan<char> piece)
    {
        var detected = ScriptGroup.None;
        var index = 0;

        while (index < piece.Length)
        {
            var rune = ReadRune(piece, index, out var consumed);
            index += consumed;

            if (!Rune.IsLetter(rune))
            {
                continue;
            }

            var group = ClassifyRune(rune);
            if (group == ScriptGroup.None)
            {
                continue;
            }

            if (detected == ScriptGroup.None)
            {
                detected = group;
                continue;
            }

            if (detected != group)
            {
                return ScriptGroup.Mixed;
            }
        }

        return detected == ScriptGroup.None ? ScriptGroup.Other : detected;
    }

    private static ScriptGroup ClassifyRune(Rune rune)
    {
        var value = rune.Value;

        if (value is <= 0x024F or >= 0x1E00 and <= 0x1EFF)
        {
            return ScriptGroup.Latin;
        }

        if (value is >= 0x0370 and <= 0x03FF or >= 0x1F00 and <= 0x1FFF
            or >= 0x0400 and <= 0x052F or >= 0x2DE0 and <= 0x2DFF or >= 0xA640 and <= 0xA69F)
        {
            return ScriptGroup.CyrillicOrGreek;
        }

        if (value is >= 0x0590 and <= 0x05FF or >= 0x0600 and <= 0x06FF or >= 0x0750 and <= 0x077F or >= 0x08A0 and <= 0x08FF)
        {
            return ScriptGroup.ArabicHebrew;
        }

        if (value is >= 0x3040 and <= 0x30FF or >= 0x31F0 and <= 0x31FF or >= 0x3400 and <= 0x4DBF
            or >= 0x4E00 and <= 0x9FFF or >= 0xAC00 and <= 0xD7AF or >= 0xF900 and <= 0xFAFF)
        {
            return ScriptGroup.CjkOrKanaOrHangul;
        }

        return ScriptGroup.Other;
    }

    private static bool AllSameChar(ReadOnlySpan<char> value)
    {
        if (value.Length <= 1)
        {
            return true;
        }

        var first = value[0];

        for (var index = 1; index < value.Length; index++)
        {
            if (value[index] != first)
            {
                return false;
            }
        }

        return true;
    }

    private static int CeilingDiv(int value, int divisor)
    {
        if (value <= 0)
        {
            return 0;
        }

        return (value + divisor - 1) / divisor;
    }

    private readonly record struct ToolField(string Value, bool IsStructured);

    private enum ScriptGroup
    {
        None,
        Latin,
        CyrillicOrGreek,
        ArabicHebrew,
        CjkOrKanaOrHangul,
        Other,
        Mixed
    }
}
