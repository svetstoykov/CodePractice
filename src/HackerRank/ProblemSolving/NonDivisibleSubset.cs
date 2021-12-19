using System;
using System.Collections.Generic;

namespace HackerRank.ProblemSolving
{
    public static class NonDivisibleSubset
    {
        public static int GetResult(int k, List<int> s)
        {
            var remainderArr = new int[k];
            foreach (var el in s)
            {
                remainderArr[el % k]++;
            }

            var zeroRemainder = remainderArr[0];
            var maxNumberOfDivisibleSet = zeroRemainder > 0 ? 1 : 0;


            for (int i = 1; i <= (k / 2); i++)
            {
                if (i != k - i)
                {
                    maxNumberOfDivisibleSet += Math.Max(remainderArr[i], remainderArr[k - i]);
                }
                else
                {
                    maxNumberOfDivisibleSet++;
                }
            }

            return maxNumberOfDivisibleSet;
        }
    }
}
