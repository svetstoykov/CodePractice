namespace HackerRank.ProblemSolving
{
    public class LarrysArray
    {
        public static string GetResult(int[] A)
        {
            var swaps = 0;

            for (int i = 1; i < A.Length; ++i)
            {
                int key = A[i];
                int j = i - 1;

                // Move elements of arr[0..i-1], 
                // that are greater than key, 
                // to one position ahead of 
                // their current position 
                while (j >= 0 && A[j] > key)
                {
                    A[j + 1] = A[j];
                    swaps++;
                    j = j - 1;
                }
                A[j + 1] = key;
            }

            return "NO";
        }

        private static int[] Rotate(int[] arr)
        {
            var firstEl = arr[0];
            var secondEl = arr[1];
            var thirdEl = arr[2];

            arr[0] = secondEl;
            arr[1] = thirdEl;
            arr[2] = firstEl;

            return arr;
        }

        private static bool IsSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] + 1 != arr[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
