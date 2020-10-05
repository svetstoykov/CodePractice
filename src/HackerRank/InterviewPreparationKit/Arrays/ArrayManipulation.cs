using System;

namespace HackerRank.InterviewPreparationKit
{
    public static class ArrayManipulation
    {
        public static long GetResult(int n, int[][] queries)
        {

            long[] outputArray = new long[n + 2];
            foreach (var num in queries)
            {
                int a = num[0];
                int b = num[1];
                int k = num[2];
                outputArray[a] += k;
                outputArray[b + 1] -= k;
            }
            long max = getMax(outputArray);
            return max;
        }

        private static long getMax(long[] inputArray)
        {
            long max = long.MinValue;
            long sum = 0;
            foreach (var num in inputArray)
            {
                sum += num;
                max = Math.Max(max, sum);
            }
            return max;
        }
	}
}
