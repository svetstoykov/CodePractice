namespace HackerRank.ProblemSolving
{
    public static class SaveThePrisoner
    {
        public static int GetResult(int n, int m, int s)
        {
            
            return ((m - 1) + (s - 1))% n + 1;
        }
    }
}
