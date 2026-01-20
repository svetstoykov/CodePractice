namespace Leetcode.LeetCode_75.Two_Pointer;

public class Max_Number_of_K_Sum_Pairs
{
    public int MaxOperations(int[] nums, int k) 
    {
        var map = new Dictionary<int, int>();
        var operations = 0;
        
        for (int i = 0; i < nums.Length; i++)
        {
            var currentNum = nums[i];
            var diff = k - currentNum;

            if (map.TryGetValue(diff, out int repeated) && repeated > 0)
            {
                operations++;
                map[diff] -= 1;
            }
            else
            {
                if (!map.TryAdd(currentNum, 1))
                {
                    map[currentNum] += 1;
                }
            }
        }

        return operations;
    }
}