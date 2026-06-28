namespace Leetcode.TopInterview_150;

public class Rotate_Array
{
    public void Rotate(int[] nums, int k)
    {
        var moveIndexLenght = k % nums.Length;
        
        Reverse(nums, 0, nums.Length - 1);
        
        Reverse(nums, 0, moveIndexLenght - 1);
        
        Reverse(nums, moveIndexLenght, nums.Length - 1);
    }

    public void Reverse(int[] nums, int start, int end)
    {
        while (start < end)
        {
            (nums[start], nums[end]) = (nums[end], nums[start]);

            start++;
            end--;
        }
    }
    

    private void SolveWithQueue(int[] nums, int k)
    {
        var queue = new Queue<int>();

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            queue.Enqueue(nums[i]);
        }

        var times = k % nums.Length;
        for (int i = 0; i < times; i++)
        {
            var num = queue.Dequeue();

            queue.Enqueue(num);
        }

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            nums[i] = queue.Dequeue();
        }
    }
}