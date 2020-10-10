using System;
using System.Collections.Generic;

namespace HackerRank.ProblemSolving
{
    public static class QueensAttack
    {

        // Not finished.
        public static int GetResult(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            var attackRow = new HashSet<int>();
            var attackCol= new HashSet<int>();
            var attackLeftDiagonal = new HashSet<int>();
            var attackRightDiagonal = new HashSet<int>();

            var rightDiagLenght = new Dictionary<int,int>();

            var movesPossible = 0;

            var currentDiag = 0;
            for (int i = 1; i <= n * 2; i++)
            {
                if (i <= n)
                {
                    currentDiag++;
                    rightDiagLenght[i] = currentDiag;
                }
                else
                {
                    currentDiag--;
                    rightDiagLenght[i] = currentDiag;
                }

            }
            

            attackRow.Add(r_q);
            attackCol.Add(c_q);
            attackLeftDiagonal.Add(c_q - r_q);
            attackRightDiagonal.Add(c_q + r_q);

            for (int i = 0; i < k; i++)
            {
                var obstRow = obstacles[i][0];
                var obstCol = obstacles[i][1];

                var obstLeftDiag = obstCol - obstRow;
                var obstRightDiag = obstCol + obstRow;

                if (attackRow.Contains(obstRow))
                {
                    var distance = Math.Abs(r_q - obstRow) - 1;

                    if (distance > 0)
                    {
                        movesPossible += distance + (n - r_q);
                    }
                    else
                    {
                        movesPossible += distance + (r_q - 1);
                    }

                } else if (attackCol.Contains(obstCol))
                {

                    var distance = Math.Abs(r_q - obstRow) - 1;

                    if (distance > 0)
                    {
                        movesPossible += distance + (n - c_q);
                    }
                    else
                    {
                        movesPossible += distance + (c_q - 1);
                    }

                } else if (attackLeftDiagonal.Contains(obstCol - obstRow))
                {
                    var distance = Math.Max(Math.Abs(obstCol - c_q), Math.Abs(obstRow - r_q)) - 1;

                    if (r_q > obstRow)
                    {
                        movesPossible += distance + (n - obstRow);
                    }
                    else
                    {
                        movesPossible += distance + (r_q - 1);
                    }

                } else if (attackRightDiagonal.Contains(obstCol + obstRow))
                {
                    var distance = Math.Max(Math.Abs(obstCol - c_q), Math.Abs(obstRow - r_q)) - 1;

                    // TO DO...
                }

            }


            return movesPossible;
        }
    }
}
