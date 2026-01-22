namespace Leetcode.LeetCode_75.Sliding_Window;

public class Max_Consecutive_Ones_3
{
    public int LongestOnes(int[] nums, int k)
    {
        int left = 0;
        int zerosCount = 0;
        int maxLength = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            // 1. Expand window: add nums[right]
            if (nums[right] == 0) zerosCount++;
    
            // 2. If window is invalid (too many zeros), SHRINK from left
            while (zerosCount > k)
            {
                if(nums[left] == 0) zerosCount--;
                
                left++;
            }
    
            // 3. Update max length (window is valid here)
            maxLength = Math.Max(maxLength, right - left + 1);
        }
        
        return maxLength;
    }
}