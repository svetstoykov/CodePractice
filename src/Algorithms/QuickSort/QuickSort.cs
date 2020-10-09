using System.Collections.Generic;
using System.Linq;

namespace Algorithms.QuickSort
{
    public static class QuickSort
    {
        public static void Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                var pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Sort(arr, pivot + 1, right);
                }
            }

        }

        private static int Partition(int[] arr, int left, int right)
        {
            // Get approximate middle value as pivot
            int pivot = arr[(left + right) / 2];

            while (true)
            {
                // If the value left of the pivot is bigger, than the pivot - it's ok go on.
                // However if its smaller, we increment until we find a bigger one.
                while (arr[left] < pivot)
                {
                    left++;
                }

                //Vice versa as arr[left],
                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right])
                        return right;

                    // Once we have found values, which are not
                    // on the correct side of the pivot, we switch them.
                    var temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
