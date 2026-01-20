namespace Leetcode.LeetCode_75.Array_String;

public class Increasing_Triplet_Subsequence
{
    public bool IncreasingTriplet(int[] nums)
    {
        var first = int.MaxValue;
        var second = int.MaxValue;

        for (int i = 0; i < nums.Length; i++)
        {
            var current =  nums[i];

            if (current < first)
            {
                first = current;
                continue;
            }

            if (current < second && current > first)
            {
                second = current;
                continue;
            }

            if (current > second)
            {
                return true;
            }
        }

        return false;
    }
}