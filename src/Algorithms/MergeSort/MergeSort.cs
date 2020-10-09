using System.Globalization;

namespace Algorithms.MergeSort
{
    public static class MergeSort
    {

        public static int[] Sort(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return arr;
            }

            var midpoint = arr.Length / 2;

            var leftArr = new int[midpoint];
            var rightArr = arr.Length % 2 == 0 
                ? new int[midpoint] 
                : new int[midpoint + 1];

            for (int i = 0; i < midpoint; i++)
            {
                leftArr[i] = arr[i];
            }

            for (int i = 0; i < rightArr.Length; i++)
            {
                rightArr[i] = arr[i + midpoint];
            }

            leftArr = Sort(leftArr);
            rightArr = Sort(rightArr);

            var result = Merge(leftArr, rightArr);

            return result;
        }
        public static int[] Merge(int[] leftArr, int[] rightArr)
        {
            int[] result = new int[leftArr.Length + rightArr.Length];
            int resultIndex, leftIndex, rightIndex;
            rightIndex = leftIndex = resultIndex = 0;

            while (leftIndex < leftArr.Length || rightIndex < rightArr.Length)
            {
                if (leftIndex < leftArr.Length && rightIndex < rightArr.Length)
                {
                    if (leftArr[leftIndex] <= rightArr[rightIndex])
                    {
                        result[resultIndex] = leftArr[leftIndex];
                        resultIndex++;
                        leftIndex++;
                    }
                    else
                    {
                        result[resultIndex] = rightArr[rightIndex];
                        resultIndex++;
                        rightIndex++;
                    }
                } else if (leftIndex < leftArr.Length)
                {
                    result[resultIndex] = leftArr[leftIndex];
                    resultIndex++;
                    leftIndex++;
                }
                else if (rightIndex < rightArr.Length)
                {
                    result[resultIndex] = rightArr[rightIndex];
                    resultIndex++;
                    rightIndex++;
                }
            }

            return result;
        }

    }
}
