using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.InterviewPreparationKit.Sorting
{
    public class FraudulentActivityNotifications
    {
        public static int GetResult(int[] expenditure, int d)
        {

            var queue = new Queue<int>(expenditure);
            var median = GetMedian(d, queue);
            var result = 0;

            while (d < queue.Count)
            {
                var currentDaySpending = queue.Skip(d).First();

                if (currentDaySpending >= 2 * median)
                {
                    result++;
                }

                queue.Dequeue();
                median = GetMedian(d, queue);
            }

            return result;
        }

        private static double GetMedian(int d, Queue<int> queue)
        {
            var expenses = CountedSort(queue.Take(d).ToArray());

            if (d % 2 != 0)
            {
                return expenses[(int)Math.Floor(expenses.Length / 2d)];
            }

            return expenses.Skip(expenses.Length / 2 - 1).Take(2).Average();
        }

        private static int[] CountedSort(int[] array)
        {
            int[] sortedArray = new int[array.Length];

            // find smallest and largest value
            int minVal = array[0];
            int maxVal = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minVal)
                {
                    minVal = array[i];
                }
                else if (array[i] > maxVal)
                {
                    maxVal = array[i];
                }

            }

            // init array of frequencies
            int[] counts = new int[maxVal - minVal + 1];

            // init the frequencies
            for (int i = 0; i < array.Length; i++)
            {
                counts[array[i] - minVal]++;
            }

            // recalculate
            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] = counts[i] + counts[i - 1];
            }

            // Sort the array
            for (int i = array.Length - 1; i >= 0; i--)
            {
                sortedArray[counts[array[i] - minVal]--] = array[i];
            }

            return sortedArray;
        }
    }
}
