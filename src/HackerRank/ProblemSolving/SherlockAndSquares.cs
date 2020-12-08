using System;
using System.Collections.Generic;

namespace HackerRank.ProblemSolving
{
    public class SherlockAndSquares
    {
        public static int GetResult(int a, int b)
        {
            var startRoot = a;
            var endRoot = b;

            while (true)
            {
                if (isSquareRoot(startRoot))
                {
                    break;
                }

                if (startRoot == endRoot)
                {
                    return 0;
                }

                startRoot++;
            }

            while (true)
            {
                if (isSquareRoot(endRoot))
                {
                    break;
                }

                endRoot--;
            }


            return (int)(Math.Sqrt(endRoot) - Math.Sqrt(startRoot)) + 1;
        }

        private static bool isSquareRoot(int value)
        {
            return Math.Abs(Math.Sqrt(value) % 1) <= (Double.Epsilon * 100);
        }

    }
}
