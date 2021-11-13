using System.Collections.Generic;

namespace HackerRank.ProblemSolving
{
    public static class BreakingTheRecords
    {
        public static List<int> GetResult(List<int> scores)
        {
            int recordBrokenMin = 0;
            int recordBrokenMax = 0;

            int currentMin = 0;
            int currentMax = 0;
            
            for (int i = 0; i < scores.Count; i++)
            {
                int currentScore = scores[i];

                if(i == 0)
                {
                    currentMax = currentScore; 
                    currentMin = currentScore;
                    continue;
                }

                if(currentScore < currentMin)
                {
                    currentMin = currentScore;
                    recordBrokenMin++;
                    continue;
                }

                if(currentScore > currentMax)
                {
                    currentMax = currentScore;
                    recordBrokenMax++;
                }
            }

            return new List<int> { recordBrokenMax, recordBrokenMin };
        }
    }
}
