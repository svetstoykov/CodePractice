namespace Leetcode.Problems
{
    public static class MaximumSubarray
    {
        public static int Solve(int[] nums)
        {
            var maxSum = nums[0];
            var currSum = 0;

            foreach (var t in nums)
            {
                if (currSum < 0)
                {
                    currSum = 0;
                }

                currSum += t;
                maxSum = Math.Max(currSum, maxSum);
            }

            return maxSum;
        }
    }
}
