using System;

namespace HackerRank
{
    public static class CatAndMouse
    {
        public static string GetResult(int x, int y, int z)
        {
            var catOneDistance = Math.Abs(x - z);
            var catTwoDistance = Math.Abs(y - z);

            if (catOneDistance == catTwoDistance)
            {
                return "Mouse C";
            }

            return catOneDistance < catTwoDistance ? "Cat A" : "Cat B";
        }
    }
}
