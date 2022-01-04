namespace Leetcode.Problems
{
    public static class LongestIncreasingSubsequence
    {
        public static int Solve(int[] nums)
        {
            var LIS = Enumerable.Repeat(1, nums.Length).ToArray();

            for (int i = nums.Length - 1; i > 0; i--)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        LIS[i] = Math.Max(LIS[i], 1 + LIS[j]);
                    }
                }
            }

            return LIS.Max();
        }
    }
}
