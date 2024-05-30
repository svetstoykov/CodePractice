using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.ProblemSolving
{
    public class CutTheSticks
    {
        public static List<int> Solve(List<int> arr)
        {
            arr.Sort();
            var smallest = arr[0];
            var result = new List<int> {arr.Count};

            while (arr.Count > 1)
            {
                if (arr.All(e => e == smallest))
                {
                    break;
                }

                arr = arr.Select(e => e - smallest)
                    .Where(e => e > 0)
                    .ToList();

                smallest = arr[0];

                result.Add(arr.Count);
            }

            return result;
        }
    }
}