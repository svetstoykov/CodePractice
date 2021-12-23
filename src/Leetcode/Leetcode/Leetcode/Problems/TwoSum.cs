namespace Leetcode.Problems
{
    public static class TwoSum
    {
        public static int[] Solve(int[] nums, int target)
        {
            var viableNumbers = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var currentNum = nums[i];
                if (viableNumbers.TryGetValue(target - currentNum, out var value))
                {
                    return new int[] {value, i};
                }

                if (!viableNumbers.ContainsKey(currentNum))
                {
                    viableNumbers.Add(currentNum, i);
                }
            }

            return new int[] { };
        }
    }
}
