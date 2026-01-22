using System.Diagnostics.Tracing;

namespace Leetcode.LeetCode_75.Prefix_Sum;

public class Find_Pivot_Index
{
    public int PivotIndex(int[] nums)
    {
        var total = nums.Sum();
        var left = 0;
        
        // тотал = left + num[i] + right

        for (int i = 0; i < nums.Length; i++)
        {
            var right = total - left - nums[i];
            if (left == right) return i;
            left += nums[i];
        }

        return -1;
    }
}