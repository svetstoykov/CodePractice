using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HackerRank.InterviewPreparationKit.DictionariesAndHashmaps;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> ans = FrequencyQueries.GetResult(queries);

            Console.WriteLine(String.Join("\n", ans));
        }

    }
}


