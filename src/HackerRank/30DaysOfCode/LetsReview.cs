using System;

namespace HackerRank._30DaysOfCode
{
    public static class LetsReview
    {
        public static void GetResult()
        {
            var T = int.Parse(Console.ReadLine());

            for (int i = 0; i < T; i++)
            {
                var text = Console.ReadLine();
                var odd = "";
                var even = "";


                for (int j = 0; j < text.Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        even += text[j];
                    }
                    else
                    {
                        odd += text[j];
                    }
                }

                Console.WriteLine($"{even} {odd}");
            }

        }

    }
}
