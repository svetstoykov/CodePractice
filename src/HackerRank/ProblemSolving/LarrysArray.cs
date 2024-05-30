using System.Collections.Generic;

namespace HackerRank.ProblemSolving
{
    public class LarrysArray
    {
        public static string GetResult(List<int> A)
        {
            var revCount = 0;
            for (var i = 0; i < A.Count - 1; i++) {
                for (var j = i + 1; j < A.Count; j++) {
                    if (A[i] > A[j]) {
                        revCount += 1;
                    }
                }
            }

            return revCount % 2 == 0 ? "YES" : "NO";
        }
    }
}
