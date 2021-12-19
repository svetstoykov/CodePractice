using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static class PickingNumbers
    {

        public static int GetResult(List<int> a)
        {
            var sorted = a.OrderBy(x => x).ToList();
            var longest = 0;
            var results = new List<int>();
            var first = sorted[0];

            for (int i = 0; i < sorted.Count - 1; i++)
            {
                var currentNum = sorted[i];
                var nextNum = sorted[i + 1];

                longest++;

                if (first + 1 < nextNum || currentNum + 1 < nextNum)
                {
                    results.Add(longest);
                    first = nextNum;
                    longest = 0;
                }
            }

            return results.Count > 0 
                ? results.OrderByDescending(c => c).ToList()[0]
                : longest + 1;
        }

    }
}
