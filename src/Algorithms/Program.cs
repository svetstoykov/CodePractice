using System;
using System.Collections.Generic;
using Algorithms.BinarySearch;
using Algorithms.Combinatorial;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            for (int i = 0; i < 1200000; i++)
            {
                list.Add(i);
            }

            var arr = list.ToArray();
            var permutation = BinarySearchRecursive.Search(arr, 1200000, 0, arr.Length - 1);

            Console.WriteLine(permutation);
        }
    }
}
