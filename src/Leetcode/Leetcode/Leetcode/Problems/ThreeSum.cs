using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Problems
{
    public static class ThreeSum
    {
        public static IList<IList<int>> Solve(int[] nums)
        {

            var sortedNums = nums.OrderBy(x => x).ToList();
            var result = new List<IList<int>>();

            for (var i = 0; i < sortedNums.Count(); i++)
            {
                var leadingNum = sortedNums[i];
                if (i != 0 && leadingNum == sortedNums[i - 1])
                {
                    continue;
                }

                var l = i + 1;
                var r = sortedNums.Count() - 1;

                while (l < r)
                {
                    var sum = leadingNum + sortedNums[l] + sortedNums[r];
                    if (sum == 0)
                    {
                        result.Add(new List<int> { leadingNum, sortedNums[l], sortedNums[r] });
                        l++;
                        while ((sortedNums[l] == sortedNums[l - 1]) && l < r)
                        {
                            l++;
                        }
                    }

                    if (sum > 0)
                    {
                        r--;
                        continue;
                    }

                    l++;
                }
            }

            return result;
        }
    }
}
