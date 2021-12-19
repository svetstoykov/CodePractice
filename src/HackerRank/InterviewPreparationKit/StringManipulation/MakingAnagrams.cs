using System;
using System.Linq;

namespace HackerRank.InterviewPreparationKit.StringManipulation
{
    public static class MakingAnagrams
    {

        public static int GetResult(string a, string b)
        {
            var freq = new int[26];

            foreach (var c in a)
            {
                freq[c - 97]++;
            }

            foreach (var c in b)
            {
                freq[c - 97]--;
            }

            return freq.Select(Math.Abs).Sum();
        }

    }
}
