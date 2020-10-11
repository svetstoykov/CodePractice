using Algorithms.Combinatorial;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 2, 3 };
            var permutation = new Permutation(arr);

            permutation.PermuteWithSwap(0);
        }
    }
}
