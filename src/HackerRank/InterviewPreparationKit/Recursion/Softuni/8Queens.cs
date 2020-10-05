using System;
using System.Collections.Generic;

namespace HackerRank.InterviewPreparationKit.Recursion.Softuni
{
    public class _8Queens
    {
        private const int Size = 8;
        private readonly bool[,] _board = new bool[Size, Size];
        private int solutions = 0;

        private static readonly HashSet<int> attackedRows = new HashSet<int>();
        private static readonly HashSet<int> attackedColumns = new HashSet<int>();
        private static readonly HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static readonly HashSet<int> attackedRightDiagonals = new HashSet<int>();

        public void GetResult()
        {
            PutQueen(0);
        }

        private void PutQueen(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (var col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAttackedPositions(row, col);
                        PutQueen(row +1);
                        UnmarkAttackedPositions(row, col);
                    } 

                }
            }
        }

        private void UnmarkAttackedPositions(int row, int col)
        {
            attackedRows.Remove(row);
            attackedColumns.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(col + row);
            this._board[row, col] = false;
        }

        private void MarkAttackedPositions(int rowInput, int colInput)
        {
            attackedRows.Add(rowInput);
            attackedColumns.Add(colInput);
            attackedLeftDiagonals.Add(colInput - rowInput);
            attackedRightDiagonals.Add(colInput + rowInput);
            this._board[rowInput, colInput] = true;
        }

        private bool CanPlaceQueen(int row, int col)
        {
            var placeOccupied = attackedRows.Contains(row) 
                                || attackedColumns.Contains(col)
                                || attackedLeftDiagonals.Contains(col - row) 
                                || attackedRightDiagonals.Contains(col + row);

            return !placeOccupied;
        }

        private void PrintSolution()
        {
            var boardLength = this._board.GetLength(1);

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (this._board[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            this.solutions++;

            Console.WriteLine($"Solutions: {this.solutions}");

        }

    }
}
