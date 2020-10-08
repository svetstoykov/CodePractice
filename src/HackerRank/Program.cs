using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using HackerRank.InterviewPreparationKit.Search;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = new int[] {1,4,5};
            var arr2 = new int[] { 2,3,3};
            var arr3 = new int[] { 1,2,3};

            Console.WriteLine(Triplets.GetResult(arr1,arr2,arr3));
        }



        public static string smallestString(long weight)
        {
            var lettersDict = new Dictionary<char, long>();
            var result = string.Empty;

            for (int i = 0; i < 26; i++)
            {
                if (i == 0)
                {
                    lettersDict['A'] = 1;
                }
                else
                {
                    var currentChar = (char)(i + 65);
                    var previousChar = (char)(i + 64);

                    lettersDict[currentChar] = (i + 1) * lettersDict[previousChar] + lettersDict[previousChar];
                }

            }

            lettersDict = lettersDict.OrderByDescending(c => c.Value).ToDictionary(c => c.Key, v => v.Value);

            while (weight > 0)
            {
                var currentBiggest = lettersDict.First(c => c.Value <= weight);

                result += currentBiggest.Key;

                weight -= currentBiggest.Value;
            }


            return string.Join("", result.OrderBy(c => c));

        }

        public static long maxSum(List<long> arr, long threshold)
        {
            long result = 0;
            var orderedArr = arr.OrderByDescending(c => c).ToList();
            var nums = new List<long>();

            for (int i = 0; i < orderedArr.Count(); i++)
            {

                if (threshold - orderedArr[i] < 0)
                {
                    continue;
                }

                threshold -= orderedArr[i];
                nums.Add(orderedArr[i]);
            }

            return nums.Sum();
        }


    }
}


