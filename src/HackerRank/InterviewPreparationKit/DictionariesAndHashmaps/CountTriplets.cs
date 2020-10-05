using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HackerRank.InterviewPreparationKit.DictionariesAndHashmaps
{
    public static class CountTriplets
    {
        public static long GetResult(List<long> arr, long r)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var result = 0;
            arr = arr.OrderBy(n => n).ToList();

            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i + 1; j < arr.Count; j++)
                {
                    for (int k = j + 1; k < arr.Count; k++)
                    {
                        if (arr[i] < arr[j] && arr[j] < arr[k])
                        {
                            if (arr[i] * r == arr[j] && arr[j] * r == arr[k])
                            {
                                result++;
                            }
                        }
                    }
                    
                }
            }

            Console.WriteLine(stopwatch.Elapsed);

            return result;

        }


        public static long GetResultTwo(List<long> arr, long r)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();


            var rightMap = GetOccurenceMap(arr);
            var leftMap = new Dictionary<long, long>();
            long numOfPair = 0;

            foreach (var val in arr)
            {
                long countLeft = 0;
                long countRight = 0;
                long lhs = 0;
                long rhs = val * r;

                if (val % r == 0)
                {
                    lhs = val / r;
                }

                var occurance = rightMap[val];
                rightMap[val] += val + 1L;

                if (rightMap.ContainsKey(rhs))
                {
                    countRight = rightMap[rhs];
                }

                if (leftMap.ContainsKey(lhs))
                {
                    countRight = leftMap[lhs];
                }

                numOfPair += countLeft * countRight;
                InsertIntoMap(leftMap,val);
            }

            Console.WriteLine(stopwatch.Elapsed);

            return numOfPair;

        }

        private static Dictionary<long, long> GetOccurenceMap(List<long> test)
        {
            var occurenceMap = new Dictionary<long, long>();
            foreach (var val in test)
            {
                InsertIntoMap(occurenceMap, val);
            }
            return occurenceMap;
        }

        private static void InsertIntoMap(Dictionary<long, long> occurenceMap, long val)
        {
            if (!occurenceMap.ContainsKey(val))
            {
                occurenceMap[val] = 1;
            }
            else
            {
                var occurence = occurenceMap[val];
                occurenceMap[val] += occurence + 1L;
            }
        }

    }
}
