using System;
using System.Linq;

namespace HackerRank.InterviewPreparationKit.GreedyAlgoritms
{
    public static class MinimumAbsoluteDifference
    {
        public static int GetResult(int[] arr)
        {
            var hash = arr.OrderBy(c => c).ToArray();
            var minValue = int.MaxValue;

            for (int i = 0; i < hash.Length - 1; i++)
            {
                var absDiff = Math.Abs(hash[i] - hash[i + 1]);

                if (absDiff < minValue)
                {
                    minValue = absDiff;
                }

            }

            return minValue;
        }
    }
}
