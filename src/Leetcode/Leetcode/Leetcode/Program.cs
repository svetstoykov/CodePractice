using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Globalization;
using Leetcode.Test;
using Leetcode.Test.Models;
using Leetcode.Test.Models.Content;
using Leetcode.Test.Models.Enums;
using Microsoft.ML.Tokenizers;

var unicode = new UnicodeTokenCounter();
var improvedUnicode = new ImprovedUnicodeTokenCounter();
var estimated = new EstimatedTokenCounter();
var benchmarkTokenizer = TiktokenTokenizer.CreateForModel("gpt-5");
var benchmarkJsonOptions = new JsonSerializerOptions
{
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    WriteIndented = false,
};

var samplesRoot = Path.Combine(AppContext.BaseDirectory, "Test", "Files");
if (!Directory.Exists(samplesRoot))
{
    throw new DirectoryNotFoundException($"Tokenizer sample directory was not found: {samplesRoot}");
}

var groups = new[]
{
    new SampleGroup(
        "User",
        Path.Combine(samplesRoot, "User"),
        static (sampleName, content) => ContextMessage.FromText(MessageRole.User, content)),
    new SampleGroup(
        "ToolUse",
        Path.Combine(samplesRoot, "ToolUse"),
        static (sampleName, content) => ContextMessage.FromContent(
            MessageRole.Model,
            new ToolUseContent(BuildToolCallId(sampleName), BuildToolName(sampleName), content))),
    new SampleGroup(
        "ToolResult",
        Path.Combine(samplesRoot, "ToolResult"),
        static (sampleName, content) => ContextMessage.FromContent(
            MessageRole.Tool,
            new ToolResultContent(BuildToolCallId(sampleName), BuildToolName(sampleName), content))),
};

var allResults = new List<SampleResult>();

WriteRule();
Console.WriteLine("Tokenizer comparison runner");
Console.WriteLine($"Samples root : {samplesRoot}");
Console.WriteLine("Benchmark    : Microsoft.ML.Tokenizers Tiktoken(gpt-4o) over normalized message JSON");
Console.WriteLine("Counters     : UnicodeTokenCounter vs ImprovedUnicodeTokenCounter vs EstimatedTokenCounter");
WriteRule();

foreach (var group in groups)
{
    if (!Directory.Exists(group.DirectoryPath))
    {
        throw new DirectoryNotFoundException($"Sample group directory was not found: {group.DirectoryPath}");
    }

    var filePaths = Directory
        .GetFiles(group.DirectoryPath)
        .OrderBy(Path.GetFileName, StringComparer.OrdinalIgnoreCase)
        .ToArray();

    if (filePaths.Length == 0)
    {
        Console.WriteLine();
        Console.WriteLine($"[{group.Name}] no samples found.");
        continue;
    }

    Console.WriteLine();
    WriteRule();
    Console.WriteLine($"[{group.Name}] {filePaths.Length} samples");
    WriteRule();

    foreach (var filePath in filePaths)
    {
        var fileName = Path.GetFileName(filePath);
        var sampleName = Path.GetFileNameWithoutExtension(filePath);
        var content = File.ReadAllText(filePath, Encoding.UTF8);
        var message = group.CreateMessage(sampleName, content);
        var benchmarkPayload = SerializeBenchmarkPayload(message);

        var result = new SampleResult(
            GroupName: group.Name,
            FileName: fileName,
            CharacterCount: content.Length,
            Utf8ByteCount: Encoding.UTF8.GetByteCount(content),
            LineCount: CountLines(content),
            BenchmarkCount: benchmarkTokenizer.CountTokens(benchmarkPayload),
            UnicodeCount: unicode.Count(message),
            ImprovedUnicodeCount: improvedUnicode.Count(message),
            EstimatedCount: estimated.Count(message));

        allResults.Add(result);

        Console.WriteLine($"• {group.Name}/{result.FileName}");
        Console.WriteLine($"  size      : chars={result.CharacterCount}, utf8-bytes={result.Utf8ByteCount}, lines={result.LineCount}");
        Console.WriteLine($"  benchmark : {result.BenchmarkCount}");
        Console.WriteLine($"  unicode   : {result.UnicodeCount} ({FormatDelta(result.UnicodeCount, result.BenchmarkCount)})");
        Console.WriteLine($"  improved  : {result.ImprovedUnicodeCount} ({FormatDelta(result.ImprovedUnicodeCount, result.BenchmarkCount)})");
        Console.WriteLine($"  estimated : {result.EstimatedCount} ({FormatDelta(result.EstimatedCount, result.BenchmarkCount)})");
        Console.WriteLine($"  closer    : {PickCloserCounter(result)}");
        Console.WriteLine();
    }

    WriteSummary(group.Name, allResults.Where(result => result.GroupName == group.Name).ToArray());
}

Console.WriteLine();
WriteRule();
Console.WriteLine("Overall summary");
WriteRule();
WriteSummary("All samples", allResults.ToArray());

return;

static string BuildToolCallId(string sampleName) => $"call-{NormalizeToken(sampleName)}";

static string BuildToolName(string sampleName) => $"sample_{NormalizeToken(sampleName)}";

static string NormalizeToken(string value)
{
    var builder = new StringBuilder(value.Length);

    foreach (var character in value)
    {
        builder.Append(char.IsLetterOrDigit(character) ? char.ToLowerInvariant(character) : '_');
    }

    return builder.ToString().Trim('_');
}

string SerializeBenchmarkPayload(ContextMessage message)
{
    var payload = new
    {
        role = message.Role switch
        {
            MessageRole.System => "system",
            MessageRole.User => "user",
            MessageRole.Model => "assistant",
            MessageRole.Tool => "tool",
            _ => "unknown",
        },
        content = message.Segments.Select(SerializeSegment).ToArray(),
    };

    return JsonSerializer.Serialize(payload, benchmarkJsonOptions);
}

static object SerializeSegment(ContentSegment segment)
{
    return segment switch
    {
        TextContent text => new
        {
            type = "text",
            text = text.Content,
        },
        ToolUseContent toolUse => new
        {
            type = "tool_use",
            id = toolUse.ToolCallId,
            name = toolUse.ToolName,
            input = ParseJsonOrText(toolUse.Content),
        },
        ToolResultContent toolResult => new
        {
            type = "tool_result",
            tool_use_id = toolResult.ToolCallId,
            name = toolResult.ToolName,
            content = ParseJsonOrText(toolResult.Content),
        },
        _ => new
        {
            type = "text",
            text = segment.Content,
        },
    };
}

static object ParseJsonOrText(string content)
{
    try
    {
        using var document = JsonDocument.Parse(content);
        return document.RootElement.Clone();
    }
    catch (JsonException)
    {
        return content;
    }
}

static int CountLines(string content)
{
    if (content.Length == 0)
    {
        return 0;
    }

    var count = 1;

    foreach (var character in content)
    {
        if (character == '\n')
        {
            count++;
        }
    }

    return count;
}

static string FormatDelta(int count, int benchmark)
{
    var delta = count - benchmark;
    var percent = benchmark == 0 ? 0d : (double)delta / benchmark * 100d;
    var sign = delta >= 0 ? "+" : string.Empty;

    return FormattableString.Invariant($"delta {sign}{delta} | {sign}{percent:0.0}%");
}

static string PickCloserCounter(SampleResult result)
{
    var unicodeDelta = Math.Abs(result.UnicodeCount - result.BenchmarkCount);
    var improvedUnicodeDelta = Math.Abs(result.ImprovedUnicodeCount - result.BenchmarkCount);
    var estimatedDelta = Math.Abs(result.EstimatedCount - result.BenchmarkCount);
    var closestDelta = Math.Min(unicodeDelta, Math.Min(improvedUnicodeDelta, estimatedDelta));
    var winners = new List<string>();

    if (unicodeDelta == closestDelta)
    {
        winners.Add("UnicodeTokenCounter");
    }

    if (improvedUnicodeDelta == closestDelta)
    {
        winners.Add("ImprovedUnicodeTokenCounter");
    }

    if (estimatedDelta == closestDelta)
    {
        winners.Add("EstimatedTokenCounter");
    }

    return winners.Count == 1 ? winners[0] : "tie";
}

static void WriteSummary(string label, IReadOnlyCollection<SampleResult> results)
{
    if (results.Count == 0)
    {
        Console.WriteLine($"{label,-12} | no results");
        return;
    }

    var unicodeWins = results.Count(result =>
        Math.Abs(result.UnicodeCount - result.BenchmarkCount) < Math.Abs(result.ImprovedUnicodeCount - result.BenchmarkCount) &&
        Math.Abs(result.UnicodeCount - result.BenchmarkCount) < Math.Abs(result.EstimatedCount - result.BenchmarkCount));
    var improvedWins = results.Count(result =>
        Math.Abs(result.ImprovedUnicodeCount - result.BenchmarkCount) < Math.Abs(result.UnicodeCount - result.BenchmarkCount) &&
        Math.Abs(result.ImprovedUnicodeCount - result.BenchmarkCount) < Math.Abs(result.EstimatedCount - result.BenchmarkCount));
    var estimatedWins = results.Count(result =>
        Math.Abs(result.EstimatedCount - result.BenchmarkCount) < Math.Abs(result.UnicodeCount - result.BenchmarkCount) &&
        Math.Abs(result.EstimatedCount - result.BenchmarkCount) < Math.Abs(result.ImprovedUnicodeCount - result.BenchmarkCount));
    var ties = results.Count - unicodeWins - improvedWins - estimatedWins;

    Console.WriteLine($"{label,-12} | average absolute delta                 -> unicode {FormatNumber(results.Average(result => Math.Abs(result.UnicodeCount - result.BenchmarkCount)))}, improved {FormatNumber(results.Average(result => Math.Abs(result.ImprovedUnicodeCount - result.BenchmarkCount)))}, estimated {FormatNumber(results.Average(result => Math.Abs(result.EstimatedCount - result.BenchmarkCount)))}");
    Console.WriteLine($"{label,-12} | average absolute percentage difference -> unicode {FormatNumber(results.Average(result => PercentDifference(result.UnicodeCount, result.BenchmarkCount)))}%, improved {FormatNumber(results.Average(result => PercentDifference(result.ImprovedUnicodeCount, result.BenchmarkCount)))}%, estimated {FormatNumber(results.Average(result => PercentDifference(result.EstimatedCount, result.BenchmarkCount)))}%");
    Console.WriteLine($"{label,-12} | closer wins   -> unicode {unicodeWins}, improved {improvedWins}, estimated {estimatedWins}, ties {ties}");
}

static double PercentDifference(int count, int benchmark)
{
    if (benchmark == 0)
    {
        return 0d;
    }

    return Math.Abs((double)(count - benchmark) / benchmark * 100d);
}

static string FormatNumber(double value) => value.ToString("0.0", CultureInfo.InvariantCulture);

static void WriteRule() => Console.WriteLine(new string('=', 88));

internal sealed record SampleGroup(
    string Name,
    string DirectoryPath,
    Func<string, string, ContextMessage> CreateMessage);

internal sealed record SampleResult(
    string GroupName,
    string FileName,
    int CharacterCount,
    int Utf8ByteCount,
    int LineCount,
    int BenchmarkCount,
    int UnicodeCount,
    int ImprovedUnicodeCount,
    int EstimatedCount);
