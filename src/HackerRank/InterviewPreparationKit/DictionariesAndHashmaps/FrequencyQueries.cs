using System.Collections.Generic;
using System.Linq;

namespace HackerRank.InterviewPreparationKit.DictionariesAndHashmaps
{
    public static class FrequencyQueries
    {
        public static List<int> GetResult(List<List<int>> queries)
        {
            var dict = new Dictionary<int, int>();
            var response = new List<int>();
            var frequencies = new Dictionary<int, int>();

            foreach (var query in queries)
            {
                var command = query[0];
                var value = query[1];

                if (command == 1)
                {
                    if (!dict.ContainsKey(value))
                    {
                        dict[value] = 0;
                    }

                    if (!frequencies.ContainsKey(dict[value]))
                    {
                        frequencies[dict[value]] = 0;
                    }

                    frequencies[dict[value]] -= 1;
                    dict[value]++;

                    if (!frequencies.ContainsKey(dict[value]))
                    {
                        frequencies[dict[value]] = 0;
                    }

                    frequencies[dict[value]] += 1;
                }
                else if (command == 2)
                {
                    if (dict.TryGetValue(value, out var amount) && amount > 0)
                    {
                        frequencies[dict[value]] -= 1;
                        dict[value]--;
                        frequencies[dict[value]] += 1;
                    }
                }
                else
                {
                    if (frequencies.TryGetValue(value, out var freqAmount) && freqAmount > 0)
                    {
                        response.Add(1);
                        continue;
                    }
                    response.Add(0);
                }
            }

            return response;
        }
        
    }
}
