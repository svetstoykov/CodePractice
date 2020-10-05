using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HackerRank.InterviewPreparationKit.DictionariesAndHashmaps
{
    public static class SherlockAndAnagrams
    {

        public static int GetResult(string s)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var anagrams = 0;
            var lettersToTake = 1;

            while (lettersToTake < s.Length)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (i + lettersToTake > s.Length)
                    {
                        break;
                    }

                    var currentLetters = string.Concat(s.Substring(i, lettersToTake).OrderBy(c => c));

                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (j + lettersToTake > s.Length)
                        {
                            break;
                        }

                        var lettersToMatch = string.Concat(s.Substring(j, lettersToTake).OrderBy(c => c));

                        if (currentLetters == lettersToMatch)
                        {
                            anagrams++;
                        }

                    }

                }

                lettersToTake++;
            }

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
            return anagrams;
        }


        public static int SecondSolution(string s)
        {
            var workingSet = new Dictionary<string, List<int>>();

            for (int i = 0; i < s.Length; i++)
            {
                var lettersToTake = i + 1;

                for (int j = 0; j < s.Length; j++)
                {
                    if (j + lettersToTake > s.Length)
                    {
                        break;
                    }

                    var str = s.Substring(j, lettersToTake);

                    if (str.Length > 1)
                    {
                        str = string.Concat(str.OrderBy(c => c));
                    }

                    if (!workingSet.ContainsKey(str))
                    {
                        workingSet[str] = new List<int>(){0};
                    }
                    else
                    {
                        var setCount = workingSet[str].Count;

                        if (setCount > 1)
                        {
                            var numToAdd = 
                                workingSet[str][setCount - 1] 
                                + workingSet[str][setCount - 2];

                            workingSet[str].Add(numToAdd);
                        }

                        workingSet[str].Add(1);

                    }
                }
            }

            return workingSet.Sum(x => x.Value.Sum());
        }
    }
}
