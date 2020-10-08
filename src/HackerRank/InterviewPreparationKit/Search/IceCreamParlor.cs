using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HackerRank.InterviewPreparationKit.Search
{
    public static class IceCreamParlor
    {
        public static void GetResult(int[] cost, int money)
        {
            var stopwatch = new Stopwatch();

            var hash = new HashSet<int>(cost);

            for (int i = 0; i < cost.Length; i++)
            {
                var currentCost = cost[i];
                var found = hash.TryGetValue(money - currentCost, out var match);

                if (found)
                {
                    var indexOfFound = Array.IndexOf(cost, match, i + 1);

                    if (indexOfFound > 0)
                    {
                        Console.WriteLine($"{i + 1} {indexOfFound + 1}");
                        break;
                    }
                }

            }

        }
    }
}
