namespace Leetcode.Problems;

public class NumberOfMatchingSubsequences
{
    public int NumMatchingSubseq(string s, string[] words)
    {
        var waiting = new Dictionary<char, List<(string word, int index)>>();

        foreach (var word in words)
        {
            var firstChar = word[0];
            if (!waiting.ContainsKey(firstChar))
            {
                waiting[firstChar] = new List<(string word, int index)>();
            }
            
            waiting[firstChar].Add((word, 0));
        }

        int count = 0;

        foreach (var c in s)
        {
            if(!waiting.ContainsKey(c)) continue;
            
            var currentBucket = waiting[c];
            waiting[c] = new List<(string word, int index)>();

            foreach (var (word, index) in currentBucket)
            {
                var nextIdx = index + 1;
                
                if (nextIdx == word.Length)
                {
                    count++;
                }
                else
                {
                    var nextChar = word[nextIdx];
                    if (!waiting.ContainsKey(nextChar))
                    {
                        waiting[nextChar] = new List<(string word, int index)>();
                    }
                    
                    waiting[nextChar].Add((word, nextIdx));
                }
            }
        }

        return count;
    }
}