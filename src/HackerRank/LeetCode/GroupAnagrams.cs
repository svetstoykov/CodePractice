using System.Collections.Generic;
using System.Linq;

namespace HackerRank.LeetCode
{
    public static class GroupAnagrams
    {
        public static IList<IList<string>> Solve(string[] strs)
        {
            var anagramsDictionary = new Dictionary<string, IList<string>>();

            foreach (var word in strs)
            {
                var orderedWord = string.Join("", word.OrderBy(w => w));

                if (anagramsDictionary.ContainsKey(orderedWord))
                {
                    anagramsDictionary[orderedWord].Add(word);
                    
                    continue;
                }

                anagramsDictionary[orderedWord] = new List<string> {word};
            }

            return anagramsDictionary.Select(e => e.Value).ToList();
        }
    }
}