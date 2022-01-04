using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Problems
{
    public static class HouseRobber
    {
        public static int Solve(int[] nums)
        {
            var rob1 = 0;
            var rob2 = 0;

            foreach (var n in nums)
            {
                var temp = Math.Max(n + rob1, rob2);
                rob1 = rob2;
                rob2 = temp;
            }

            return rob2;
        }
    }
}
