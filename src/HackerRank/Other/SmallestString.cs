using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Other
{
    public static class SmallestString
    {
        public static string GetResult(long weight)
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

                    lettersDict[currentChar] = 
                        (i + 1) * lettersDict[previousChar] + lettersDict[previousChar];
                }

            }

            lettersDict = lettersDict
                .OrderByDescending(c => c.Value)
                .ToDictionary(c => c.Key, v => v.Value);

            while (weight > 0)
            {
                var currentBiggest = lettersDict.First(c => c.Value <= weight);

                result += currentBiggest.Key;

                weight -= currentBiggest.Value;
            }

            return string.Join("", result.OrderBy(c => c));
        }
    }
}
