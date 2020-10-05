using System;

namespace HackerRank._30DaysOfCode
{
    public static class Loops
    {
        public static void GetResult(int n)
        {

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{n} x {i} = {n * i}");
            }

        }
    }
}
