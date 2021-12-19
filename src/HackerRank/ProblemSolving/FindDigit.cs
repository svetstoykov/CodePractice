using System;
using System.Linq;

namespace HackerRank.ProblemSolving
{
    public class FindDigit
    {
        public static int GetResult(int n)
        {
            var digits = n.ToString().ToCharArray().Select(Char.GetNumericValue).ToArray();
            var result = 0;

            foreach (var digit in digits)
            {
                if (n % digit == 0)
                {
                    result++;
                }
            }
            return result;
        }
    }
}
