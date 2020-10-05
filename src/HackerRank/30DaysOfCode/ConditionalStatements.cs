using System;

namespace HackerRank._30DaysOfCode
{
    public static class ConditionalStatements
    {
        public static void WierdNum(int N)
        {
            if (N % 2 != 0)
            {
                Console.WriteLine("Weird");
            } else if (N % 2 == 0 && N >= 2 && N <= 5)
            {
                Console.WriteLine("Not Weird");
            } else if (N % 2 == 0 && N >= 6 && N <= 20)
            {
                Console.WriteLine("Weird");
            }
            else
            {
                Console.WriteLine("Not Weird");
            }
        }

    }
}
