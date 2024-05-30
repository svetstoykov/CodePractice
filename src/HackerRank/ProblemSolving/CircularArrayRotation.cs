using System.Collections.Generic;
using System.Linq;

namespace HackerRank.ProblemSolving
{
    public class CircularArrayRotation
    {
        public static List<int> Solve(List<int> a, int k, List<int> queries)
        {
            a.Reverse();
            var queue = new Queue<int>(a);
            
            for (var i = 0; i < k; i++)
            {
                var item = queue.Dequeue();
                queue.Enqueue(item);
            }

            var rotatedList = queue.Reverse().ToList();
            
            return queries.Select(q => rotatedList[q]).ToList();
        }
    }
}