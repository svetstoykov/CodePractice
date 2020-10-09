using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[2000];
            var random = new Random();

            for (int i = 0; i < 2000; i++)
            {
                var num = random.Next(0, 1200);
                arr[i] = num;
            }
            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine("THIS WAS THE BROKEN ARRAY");
            Console.WriteLine();


            arr = MergeSort.MergeSort.Sort(arr);

            Console.WriteLine(string.Join(", ", arr));

        }
    }
}
