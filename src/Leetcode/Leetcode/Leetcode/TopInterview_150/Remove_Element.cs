namespace Leetcode.TopInterview_150;

public class Remove_Element
{
    public int RemoveElement(int[] nums, int val)
    {
        var endIndex = nums.Length - 1;
        var startIndex = 0;
        var matched = 0;
        
        while (startIndex < endIndex)
        {
            if (nums[startIndex] == val)
            {
                while (nums[endIndex] == val && endIndex > startIndex)
                {
                    matched++;
                    endIndex--;
                }
                
                (nums[endIndex], nums[startIndex]) = (nums[startIndex], nums[endIndex]);

                endIndex--;
                matched++;
            }
            
            startIndex++;
        }
        
        return nums.Length - matched;
    }
}