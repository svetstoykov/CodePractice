using System.Collections.Generic;
using System.Linq;

namespace HackerRank.ProblemSolving
{
    public static class ClimbingTheLeaderboard
    {
        public static List<int> GetResult(List<int> ranked, List<int> player)
        {
            var result = new List<int>();
            ranked = ranked.Distinct().ToList();

            foreach (var score in player)
            {
                var position = SearchRank(score, ranked, 0, ranked.Count - 1);

                if (ranked[position] == score)
                {
                    result.Add(position + 1);
                }
                else if(ranked[position] > score)
                {
                    result.Add(position + 2);
                }
                else
                {
                    result.Add(position + 1);
                }
            }

            return result;
        }

        private static int SearchRank(int score, List<int> scoreboard, int left, int right)
        {
            var midPoint = (left + right) / 2;

            if (left > right)
            {
                return midPoint;
            }

            if (scoreboard[midPoint] == score)
            {
                return midPoint;
            } 
            else if (scoreboard[midPoint] < score)
            {
                return SearchRank(score, scoreboard, left, midPoint - 1);
            }
            else
            {
               return SearchRank(score, scoreboard, midPoint + 1, right);
            }
        }
    }
}
