using System.Collections.Generic;
using System.Linq;

namespace HackerRank.InterviewPreparationKit.GreedyAlgoritms
{
    public static class LuckBalance
    {
        public static int GetResult(int k, int[][] contests)
        {
            var allContests = new HashSet<Contest>();
            var luckBalance = 0;

            for (int i = 0; i < contests.GetLength(0); i++)
            {
                var contest = new Contest()
                {
                    Luck = contests[i][0],
                    Important = contests[i][1] == 1
                };


                allContests.Add(contest);
            }

            var needsToWin = allContests.Count(c => c.Important) - k;
            allContests = allContests
                .OrderBy(c => !c.Important)
                .ThenBy(c => c.Luck)
                .ToHashSet();


            while (needsToWin > 0)
            {
                var contestWon = allContests.First(c => c.Luck > 0);

                contestWon.Luck = -contestWon.Luck;

                needsToWin--;
            }

            return allContests.Sum(c => c.Luck);
        }

        public class Contest
        {
            public int Luck { get; set; }

            public bool Important { get; set; }
        }
    }
}
