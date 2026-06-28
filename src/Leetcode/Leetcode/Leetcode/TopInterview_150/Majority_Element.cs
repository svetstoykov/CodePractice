namespace Leetcode.TopInterview_150;

public class Majority_Element
{
    public int MajorityElement(int[] nums)
    {
        var candidate = nums[0];
        var count = 1;   
        
        for (int i = 1; i < nums.Length; i++)
        {
            var c = nums[i];
            if (c == candidate)
            {
                count++;
            }
            else
            {
                count--;
                if (count == 0)
                {
                    candidate = c;
                    count = 1;
                }
            }
        }

        return candidate;
    }
}