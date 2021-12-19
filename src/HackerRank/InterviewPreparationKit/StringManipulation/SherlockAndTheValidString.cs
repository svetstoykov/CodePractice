using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.InterviewPreparationKit.StringManipulation
{
    public static class SherlockAndTheValidString
    {
        public static string GetResult(string s)
        {
            var dict = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (!dict.ContainsKey(c))
                {
                    dict[c] = 0;
                }

                dict[c]++;
            }

            var distinct = dict.Values.Distinct().ToList();

            if (distinct.Count == 1)
            {
                return "YES";
            }

            if (distinct.Count >= 3)
            {
                return "NO";
            }

            if (Math.Abs(distinct[0] - distinct[1]) > 1 && dict.All(c => c.Value != 1))
            {
                return "NO";
            }

            if (distinct[0] == 4 && distinct[1] == 1)
            {
                return "NO";
            }

            var countFirst = dict.Count(c => c.Value == distinct[0]);
            var countSecond = dict.Count(c => c.Value == distinct[1]);

            if (countFirst > countSecond)
            {
                return countSecond != 1 ? "NO" : "YES";
            }

            return countFirst != 1 ? "NO" : "YES";
        }

    }
}
