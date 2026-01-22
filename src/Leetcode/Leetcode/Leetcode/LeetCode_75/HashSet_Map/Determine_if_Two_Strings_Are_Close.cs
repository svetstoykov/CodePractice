namespace Leetcode.LeetCode_75.HashSet_Map;

public class Determine_if_Two_Strings_Are_Close
{
    public bool CloseStrings(string word1, string word2)
    {
        if (word1.Length != word2.Length) return false;

        var map1 = new Dictionary<char, int>();
        var map2 = new Dictionary<char, int>();

        for (int i = 0; i < word1.Length; i++)
        {
            if (map1.TryGetValue(word1[i], out int value))
            {
                map1[word1[i]] = ++value;
            }
            else
            {
                map1.Add(word1[i], 1);
            }

            if (map2.TryGetValue(word2[i], out var value2))
            {
                map2[word2[i]] = ++value2;
            }
            else
            {
                map2.Add(word2[i], 1);
            }
        }
        
        if (!map1.Keys.OrderBy(x => x).SequenceEqual(map2.Keys.OrderBy(x => x)))
            return false;
        
        var sortedFreq1 = map1.Values.OrderBy(x => x).ToList();
        var sortedFreq2 = map2.Values.OrderBy(x => x).ToList();
        
        return sortedFreq1.SequenceEqual(sortedFreq2);
    }
}