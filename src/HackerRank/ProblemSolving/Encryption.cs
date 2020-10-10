using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.ProblemSolving
{
    public static class Encryption
    {
        public static string GetResult(string s)
        {
            var noSpaceString = s.Where(c => c != ' ').ToArray();
            var sqrt = Math.Sqrt(noSpaceString.Length);
            var cols = Math.Ceiling(sqrt);
        
            var dict = new Dictionary<int, string>();
            var col = 0;

            for (int k = 0; k < noSpaceString.Length; k++)
            {
                if (col == cols)
                {
                    col = 0;
                }

                if (!dict.ContainsKey(col))
                {
                    dict[col] = "";
                }

                dict[col] += noSpaceString[k];
                col++;
            }

            return string.Join(' ', dict.Select(c => c.Value).ToArray());
        }

    }
}
