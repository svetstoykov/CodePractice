namespace Leetcode.TopInterview_150;

public class Merge_Sorted_Array
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        if (n == 0) return;
    
        var writePos = m + n - 1;
        var i = m - 1;
        var j = n - 1;

        while (writePos >= 0)
        {
            if (j < 0 || (i >= 0 && nums1[i] >= nums2[j]))
            {
                nums1[writePos] = nums1[i];
                i--;
            }
            else
            {
                nums1[writePos] = nums2[j];
                j--;
            }

            writePos--;
        }
    }
}