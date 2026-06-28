namespace Leetcode.TopInterview_150;

public class Remove_Duplicates_from_Sorted_Array_II
{
    public int RemoveDuplicates(int[] nums)
    {
        var writeIndex = 0;
        var readIndex = 1;

        var currentDuplicateCount = 0;
            
        while (readIndex < nums.Length)
        {
            if (nums[writeIndex] == nums[readIndex])
            {
                readIndex++;
                currentDuplicateCount++;
                continue;
            }

            writeIndex++;
            if (currentDuplicateCount >= 1)
            {
                writeIndex++;
            }
            
            currentDuplicateCount = 0;
            
            nums[writeIndex] = nums[readIndex];
        }

        return writeIndex + 1;
    }
}