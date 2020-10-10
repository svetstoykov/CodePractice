using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Other
{
    public static class MaxSumSubsequence
    {
        public static long GetResult(List<long> arr, long threshold)
        {
            long result = 0;
            var orderedArr = arr.OrderByDescending(c => c).ToList();
            var nums = new List<long>();

            for (int i = 0; i < orderedArr.Count(); i++)
            {

                if (threshold - orderedArr[i] < 0)
                {
                    continue;
                }

                threshold -= orderedArr[i];
                nums.Add(orderedArr[i]);
            }

            return nums.Sum();
        }

    }
}
