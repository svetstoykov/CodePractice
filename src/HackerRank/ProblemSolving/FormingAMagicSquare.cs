using System;
using System.Linq;

namespace HackerRank
{
    public static class FormingAMagicSquare
    {

        public static int GetResult(int[][] s)
        {
            var cost = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            var t = new int[,]
            {
                {4,9,2,3,5,7,8,1,6},
                {4,3,8,9,5,1,2,7,6},
                {2,9,4,7,5,3,6,1,8},
                {2,7,6,9,5,1,4,3,8},
                {8,1,6,3,5,7,4,9,2},
                {8,3,4,1,5,9,6,7,2},
                {6,7,2,1,5,9,8,3,4},
                {6,1,8,7,5,3,2,9,4},
            };

            for (int i = 0; i < 8; i++)
            {
                cost[i] = Math.Abs(t[i,0] - s[0][0])
                          + Math.Abs(t[i,1] - s[0][1])
                          + Math.Abs(t[i,2] - s[0][2]);

                cost[i] = cost[i] 
                          + Math.Abs(t[i,3] - s[1][0]) 
                          + Math.Abs(t[i,4] - s[1][1]) 
                          + Math.Abs(t[i,5] - s[1][2]);

                cost[i] = cost[i] 
                          + Math.Abs(t[i,6] - s[2][0]) 
                          + Math.Abs(t[i,7] - s[2][1]) 
                          + Math.Abs(t[i,8] - s[2][2]);
            }

            return cost.OrderBy(c => c).ToList()[0];
        }

    }
}
