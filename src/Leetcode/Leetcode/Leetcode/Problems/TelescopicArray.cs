using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Problems
{
    public static class TelescopicArray
    {
        public static bool IsTelescopic(int[] a)
        {
            if (a.Length == 1)
            {
                return true;
            }

            var l = 0;
            var r = a.Length - 1;
            var isOdd = a.Length % 2 != 0;

            var midPoint = isOdd ? a[a.Length / 2] : 0;
            while (l < r)
            {
                if (a[l] != a[r] || a[l] != l + 1)
                {
                    return false;
                }

                l++;
                r--;
            }

            return !isOdd || (midPoint != 0 && midPoint == l + 1);
        }
    }
}
