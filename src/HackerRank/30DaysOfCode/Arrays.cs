using System;

namespace HackerRank._30DaysOfCode
{
    public static class Arrays
    {
        public static void GetResult(int[] arr)
        {
            Array.Reverse(arr);

            Console.WriteLine(string.Join(' ', arr));
        }
    }
}
