namespace Leetcode.LeetCode_75.Sliding_Window;

public class Maximum_Average_Subarray_I
{
    public double FindMaxAverage(int[] nums, int k)
    {
        if (k > nums.Length) return nums.Average();

        double highest = int.MinValue;
        var window = nums.Take(k).Sum();

        for (int i = 0; i < nums.Length; i++)
        {
            var lastNumIndex = k - 1;
            if(i + lastNumIndex >= nums.Length) break;
            
            if (i > 0)
            {
                var prev = nums[i - 1];
                var next = nums[i + lastNumIndex];
                window = window - prev + next;
            }
            
            var average = window / (double) k;
            if (average > highest)
            {
                highest = average;
            }
        }
        
        return highest;
    }
}