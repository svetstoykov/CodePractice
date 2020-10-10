namespace HackerRank.ProblemSolving
{
    public static class NumberLineJumps
    {
        public static string GetResult(int x1, int v1, int x2, int v2)
        {
            var positionFirst = x1;
            var positionSecond = x2;
            var theyMet = false;

            for (int i = 0; i < 20000; i++)
            {
                positionFirst += v1;
                positionSecond += v2;

                if (positionFirst == positionSecond)
                {
                    theyMet = true;
                }
            }

            return theyMet ? "YES" : "NO";
        }
    }
}
