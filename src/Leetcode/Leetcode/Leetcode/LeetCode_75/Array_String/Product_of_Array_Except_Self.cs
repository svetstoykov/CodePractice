namespace Leetcode.LeetCode_75.Array_String;

public class Product_of_Array_Except_Self
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var n = nums.Length;
        var answer = new int[n];
    
        // Build left products directly into answer
        var left = 1;
        for (var i = 0; i < n; i++)
        {
            answer[i] = left;
            left *= nums[i];
        }
    
        // Multiply by right products
        var right = 1;
        for (var i = n - 1; i >= 0; i--)
        {
            answer[i] *= right;
            right *= nums[i];
        }
    
        return answer;
    }
}