namespace Leetcode.Problems
{
    public static class TwoSumPartTwo
    {
        public static int[] TwoSum(int[] numbers, int target)
        {
            int l = 0;
            int r = numbers.Length - 1;

            while (l < r)
            {

                var sum = numbers[l] + numbers[r];
                if (sum == target)
                {
                    break;
                }

                if (sum > target)
                {
                    r--;
                    continue;
                }

                l++;
            }

            return new int[] { l + 1, r + 1 };
        }
    }

}
