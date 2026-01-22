namespace Leetcode.LeetCode_75.Sliding_Window;

public class Longest_Subarray_After_Deleting_One_Element
{
    public int LongestSubarray(int[] nums)
    {
        int left = 0;
        var zeroCount = 0;
        var longest = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            if(nums[right] == 0) zeroCount++;

            while (zeroCount > 1)
            {
                if(nums[left] == 0) zeroCount--;

                left++;
            }
            
            longest = Math.Max(longest, right - left + 1);
        }

        return longest - 1;
    }
}