namespace Algorithms.BinarySearch
{
    public static class BinarySearchRecursive
    {

        public static bool Search(int[] arr, int numToSearch, int left, int right)
        {

            if (left > right)
            {
                return false;
            }

            // Get midpoint
            var midPoint = (left + right) / 2;

            //Lucky enough if this is our number, we return true.
            if (arr[midPoint] == numToSearch)
            {
                return true;
            } else if (numToSearch < arr[midPoint])
            {
                // We search the half in which the number is located.
                // The function is called recursively until, we find our number
                return Search(arr, numToSearch, left, midPoint - 1);
            }
            else
            {
                return Search(arr, numToSearch, midPoint + 1, right);
            }

        }

    }
}
