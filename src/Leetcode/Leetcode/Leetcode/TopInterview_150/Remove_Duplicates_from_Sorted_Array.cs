namespace Leetcode.TopInterview_150;

public class Remove_Duplicates_from_Sorted_Array
{
    public int RemoveDuplicates(int[] nums)
    {
        var writeIndex = 0;
        var readIndex = 1;
        
        //[0,0,1,1,1,2,2,3,3,4]
            
        while (readIndex < nums.Length)
        {
            if (nums[writeIndex] == nums[readIndex])
            {
                readIndex++;
                continue;
            }

            writeIndex++;
            nums[writeIndex] = nums[readIndex];
        }

        return writeIndex + 1;
    }
}