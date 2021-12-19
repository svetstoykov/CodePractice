using System.Linq;

namespace HackerRank.InterviewPreparationKit.Sorting
{
    public static class MarkAndToys
    {

        public static int GetResult(int[] prices, int k)
        {
            var sortedPrices = prices.OrderBy(p => p).ToArray();
            var amountOfToys = 0;

            for (int i = 0; i < sortedPrices.Length; i++)
            {

                if (k > sortedPrices[i])
                {
                    amountOfToys++;
                    k -= sortedPrices[i];
                }
                
            }


            return amountOfToys;
        }
    }
}
