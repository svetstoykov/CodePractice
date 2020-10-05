using System;

namespace HackerRank.InterviewPreparationKit.Recursion.Softuni
{
    public static class Lab
    {
        public static void Gen01(int index, int[] vector)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(' ', vector));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Gen01(index + 1, vector);
            }
        }

        public static void GenCouples(int[] arr, int[] vector, int index, int border)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(' ', vector));
            }
            else
            {
                for (int i = border; i < arr.Length; i++)
                {
                    vector[index] = arr[i];
                    GenCouples(arr, vector, index + 1, i);
                }
            }
        }

        public static void DrawDiagonals(int rowInput, int colInput)
        {
            var board = new int[8, 8];
            var boardLength = board.GetLength(1);
            var step = 1;

            for (int row = 0; row < boardLength; row++)
            {
                for (int col = 0; col < boardLength; col++)
                {
                    if (col == colInput || row == rowInput)
                    {
                        board[row, col] = 1;
                    }
                }
            }

            while (step < 8)
            {
                var negativeColStep = colInput - step;
                var negativeRowStep = rowInput - step;
                var positiveColStep = colInput + step;
                var positiveRowStep = rowInput + step;


                if (negativeColStep >= 0 && negativeRowStep >= 0)
                {
                    board[negativeRowStep, negativeColStep] = 1;
                }

                if (positiveColStep < boardLength && negativeRowStep >= 0)
                {
                    board[negativeRowStep, positiveColStep] = 1;
                }

                if (negativeColStep >= 0 && positiveRowStep < boardLength)
                {
                    board[positiveRowStep, negativeColStep] = 1;
                }

                if (positiveColStep < boardLength && negativeRowStep < boardLength)
                {
                    board[positiveRowStep, positiveColStep] = 1;
                }

                step++;
            }


            for (int row = 0; row < boardLength; row++)
            {
                for (int col = 0; col < boardLength; col++)
                {
                    Console.Write($"{board[row,col]} ");
                }

                Console.WriteLine();
            }

        }

    }
}
