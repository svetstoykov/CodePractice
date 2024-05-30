using System.Linq;

namespace HackerRank.ProblemSolving
{
    public class ElectronicsShop
    {
        public static int GetMoneySpent(int[] keyboards, int[] drives, int b)
        {
            var maxValue = 0;

            foreach (var keyboard in keyboards)
            {
                foreach (var drive in drives)
                {
                    var currentValue = keyboard + drive;
                    if (currentValue > maxValue && currentValue <= b)
                    {
                        maxValue = currentValue;
                    }
                }
            }

            return maxValue == 0 ? -1 : maxValue;
        }
    }
}