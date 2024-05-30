using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.ProblemSolving
{
    public class FlatlandSpaceStations
    {
        public static int GetResult(int n, int[] c)
        {
            var answer = 0;
            var sortedStations = c.OrderBy(a => a);

            for (int i = 1; i < c.Length; i++)
            {
                answer = Math.Max(answer, (c[i] - c[i - 1]) / 2);
            }

            return default;
        }
    }
}