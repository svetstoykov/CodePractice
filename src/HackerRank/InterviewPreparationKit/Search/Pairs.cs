using System.Collections.Generic;

namespace HackerRank.InterviewPreparationKit.Search
{
    public static class Pairs
    {
        public static int GetResult(int k, int[] arr)
        {
            var result = 0;
            var hash = new HashSet<int>(arr);

            foreach (var num in arr)
            {
                var numNeeded = num - k;

                if (numNeeded > 0 && hash.Contains(numNeeded))
                {
                    result++;
                }
            }

            return result;
        }
    }
}
