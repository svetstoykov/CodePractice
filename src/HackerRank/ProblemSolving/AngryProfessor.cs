using System.Linq;

namespace HackerRank.ProblemSolving
{
    public class AngryProfessor
    {
        public static string GetResult(int k, int[] a)
            => a.Count(x => x <= 0) >= k ? "NO" : "YES";

    }
}
