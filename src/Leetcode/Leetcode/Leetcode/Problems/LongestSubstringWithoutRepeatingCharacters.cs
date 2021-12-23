namespace Leetcode.Problems;

public static class LongestSubstringWithoutRepeatingCharacters
{
    public static int Solve(string s)
    {
        var result = 0;

        var charIndexMap = new Dictionary<char, int>();
        var start = 0;

        for (var end = 0; end < s.Length; end++)
        {
            if (charIndexMap.TryGetValue(s[end], out var duplicateIndex))
            {
                var length = end - start;
                result = result < length ? length : result;

                for (int i = start; i <= duplicateIndex; i++)
                {
                    charIndexMap.Remove(s[i]);
                }

                start = duplicateIndex + 1;
            }

            charIndexMap.Add(s[end], end);
        }

        var endLength = s.Length - start;
        return result < endLength ? endLength : result;
    }
}