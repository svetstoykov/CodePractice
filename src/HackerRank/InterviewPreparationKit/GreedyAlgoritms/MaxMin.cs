using System;

namespace HackerRank.InterviewPreparationKit.GreedyAlgoritms
{
    public static class MaxMin
    {
        public static int GetResult(int k, int[] arr)
        {
            Array.Sort(arr);
            var minUnfairness = int.MaxValue;

            for (int i = 0; i < arr.Length - k + 1; i++)
            {
                var currentUnfairness = arr[i + k - 1] - arr[i];

                if (currentUnfairness < minUnfairness)
                {
                    minUnfairness = currentUnfairness;
                }
            }

            return minUnfairness;
        }
    }
}
