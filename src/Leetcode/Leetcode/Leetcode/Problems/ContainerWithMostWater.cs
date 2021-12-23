namespace Leetcode.Problems
{
    public static class ContainerWithMostWater
    {
        public static int Solve(int[] height)
        {
            var l = 0;
            var r = height.Length - 1;

            var result = 0;

            while (l < r)
            {
                var rightBigger = height[l] < height[r];

                var currentArea = (rightBigger ? height[l] : height[r]) * (r - l);
                if (result < currentArea)
                {
                    result = currentArea;
                }

                if (rightBigger)
                {
                    l++;
                    continue;
                }

                r--;
            }

            return result;
        }
    }
}

