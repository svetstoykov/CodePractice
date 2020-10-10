using System;
using System.Numerics;

namespace HackerRank.ProblemSolving
{
    public static class ExtraLongFactorials
    {
        public static void GetResult(int n)
        {
            BigInteger result = 1;

            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            Console.WriteLine(result);
        }
    }
}
