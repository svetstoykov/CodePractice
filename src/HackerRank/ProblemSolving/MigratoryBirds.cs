using System.Collections.Generic;
using System.Linq;

namespace HackerRank.ProblemSolving
{
    public class MigratoryBirds
    {

        public static int GetResult(List<int> arr)
        {
            var dict = new Dictionary<int, int>();

            foreach (var number in arr)
            {
                if (!dict.ContainsKey(number))
                {
                    dict[number] = 0;
                }

                dict[number]++;
            }

            return dict
                .OrderByDescending(c => c.Value)
                .ThenBy(c => c.Key)
                .First().Key;
        }
    }
}
