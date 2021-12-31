using System;

namespace Algorithms.BinarySearch
{
    public static class BinarySearchRecursive
    {
        private static int Steps = 0;

        public static int Search(int[] arr, int numToSearch, int left, int right)
        {
            Console.WriteLine("Step: " + Steps++);
            if (left > right)
            {
                return -1;
            }

            // Get midpoint
            var midPoint = (left + right) / 2;

            //Lucky enough if this is our number, we return true.
            if (arr[midPoint] == numToSearch)
            {
                return midPoint;
            }

            return numToSearch < arr[midPoint]
                    ? Search(arr, numToSearch, left, midPoint - 1)
                    : Search(arr, numToSearch, midPoint + 1, right);
        }

    }
}
