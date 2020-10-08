using System.Collections.Generic;
using System.Linq;

namespace HackerRank.InterviewPreparationKit.Search
{
    public static class Triplets
    {
        public static long GetResult(int[] a, int[] b, int[] c)
        {
            a = a.Distinct().OrderBy(f => f).ToArray();
            b = b.Distinct().OrderBy(f => f).ToArray();
            c = c.Distinct().OrderBy(f => f).ToArray();

            var i = 0;
            var j = 0;
            long sum = 0;

            foreach (var val in b)
            {
                while (i < a.Length && a[i] <= val)
                {
                    i++;
                }

                while (j < c.Length && c[j] <= val)
                {
                    j++;
                }

                sum += i * j;
            }

            return sum;

        }

    }
}
