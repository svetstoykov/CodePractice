namespace HackerRank.ProblemSolving
{
    public static  class UtopianTree
    {
        public static int GetResult(int n)
        {
            var height = 1;
            for (var i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    height *= 2;
                    continue;
                }

                height += 1;
            }

            return height;
        }
    }
}
