namespace Leetcode.LeetCode_75.HashSet_Map;

public class Find_the_Difference_of_Two_Arrays
{
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
        var hash1 = new HashSet<int>(nums1);
        var hash2 = new HashSet<int>(nums2);

        return
        [
            hash1.Where(n => !hash2.Contains(n)).ToList(),
            hash2.Where(n => !hash1.Contains(n)).ToList()
        ];
    }
}