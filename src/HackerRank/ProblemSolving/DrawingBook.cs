using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.ProblemSolving
{
    public static class DrawingBook
    {
        public static int PageCount(int n, int p)
        {
            var startFromFront = (p - p % 2)/2;  
            var startFromBack = (n - (p - p % 2))/2;  

            return new List<int>(){startFromFront, startFromBack}.Min();
        }
    }
}