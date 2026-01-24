

using Leetcode.LeetCode_75.Array_String;
using Leetcode.LeetCode_75.HashSet_Map;
using Leetcode.LeetCode_75.Queue;
using Leetcode.LeetCode_75.Sliding_Window;
using Leetcode.LeetCode_75.Stack;
using Leetcode.LeetCode_75.Two_Pointer;
using Leetcode.Problems;
using Leetcode.TopInterview_150;

var x = new RecentCounter();

var range = new List<int> { 1, 500, 510, 700, 3500, 4000, 4200, 7000 };

foreach (var r in range)
{
    x.Ping(r);
}

Console.WriteLine();