using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HackerRank.InterviewPreparationKit.DictionariesAndHashmaps;
using HackerRank.LeetCode;
using HackerRank.ProblemSolving;

namespace HackerRank
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var respo = GroupAnagrams.Solve(new[] {"eat", "tea", "tan", "ate", "nat", "bat"});
            
            Console.WriteLine(string.Join(" / ", respo.Select(e => string.Join(", ", e))));
        }
    }
}