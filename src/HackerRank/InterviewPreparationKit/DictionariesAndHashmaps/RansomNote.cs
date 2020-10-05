using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.InterviewPreparationKit.DictionariesAndHashmaps
{
    public static class RansomNote
    {
        public static void GetResult(string[] magazine, string[] note)
        {
            Array.Sort(magazine);
            Array.Sort(note);

            var magsList = magazine.ToList();

            foreach (var word in note)
            {
                if(!magsList.Remove(word))
                {
                    Console.WriteLine("No");
                    return;
                }
            }


            Console.WriteLine("Yes");
        }
    }
}
