using System;
using System.Collections.Generic;

namespace HackerRank.InterviewPreparationKit.DictionariesAndHashmaps
{
    public static class RansomNote
    {
        public static void GetResult(List<string> magazine, List<string> note)
        {
            var magazineDict = new Dictionary<string, int>();
            foreach (var word in magazine)
            {
                if (!magazineDict.ContainsKey(word))
                {
                    magazineDict.Add(word, 1);
                    continue;
                }

                magazineDict[word] += 1;
            }

            foreach (var word in note)
            {
                if (magazineDict.TryGetValue(word, out var value) && value > 0)
                {
                    magazineDict[word] -= 1;
                    continue;
                }

                Console.WriteLine("No");
                return;
            }

            Console.WriteLine("Yes");
        }
    }
}
