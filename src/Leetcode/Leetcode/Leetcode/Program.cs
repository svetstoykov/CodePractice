

using Leetcode.LeetCode_75.Array_String;
using Leetcode.LeetCode_75.Two_Pointer;
using Leetcode.Problems;

var x = new Move_Zeroes();
int[] nums = [0,0,0, 1,2, 0];

x.MoveZeroes(nums);

Console.WriteLine(string.Join(" ", nums));