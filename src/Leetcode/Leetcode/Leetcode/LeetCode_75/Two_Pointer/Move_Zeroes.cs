namespace Leetcode.LeetCode_75.Two_Pointer;

public class Move_Zeroes
{
    public void MoveZeroes(int[] nums)
    {
        var iterator = 0;

        while (iterator < nums.Length)
        {
            var current = nums[iterator];

            if (current == 0)
            {
                var tracker = iterator + 1;

                while (tracker < nums.Length)
                {
                    var innerCur =  nums[tracker];
                    if (innerCur != 0)
                    {
                        nums[iterator] = innerCur;
                        nums[tracker] = 0;
                        break;
                    }

                    tracker++;
                }
            }
            
            iterator++;
        }
    }
}