namespace Leetcode.LeetCode_75.Array_String;

public static class Merge_Strings_Alternately
{
    public static string MergeAlternately(string word1, string word2)
    {
        var result = "";
        var shorter = word1.Length < word2.Length ? word1 : word2;
        var longer = word1.Length > word2.Length ? word1 : word2;

        var remainingLetters = longer.Substring(shorter.Length, longer.Length - shorter.Length);

        for (int i = 0; i < shorter.Length; i++)
        {
            result += word1[i];
            result += word2[i];
        }

        return result + remainingLetters;
    }
}