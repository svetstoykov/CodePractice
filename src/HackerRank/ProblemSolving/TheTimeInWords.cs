using System.Collections.Generic;

namespace HackerRank.ProblemSolving
{
    public static class TheTimeInWords
    {
        public static string GetResult(int h, int m)
        {
            int? updatedMin = null;

            if(m > 30)
            {
                updatedMin = 60 - m;
            }

            if (m == 00)
            {
                return $"{NumbersToWords[h]} o' clock";
            }
            else if (m == 15 || m == 30)
            {
                return $"{NumbersToWords[updatedMin ?? m]} past {NumbersToWords[h]}";
            }
            else if (1 <= m && m < 30)
            {
                return $"{NumbersToWords[updatedMin ?? m]} minutes past {NumbersToWords[h]}";
            }

            return $"{NumbersToWords[updatedMin ?? m]} minutes to {NumbersToWords[h + 1]}";
        }

        public static Dictionary<int, string> NumbersToWords { get; set; } = new Dictionary<int, string>()
        {
            [1] = "one",
            [2] = "two",
            [3] = "three",
            [4] = "four",
            [5] = "five",
            [6] = "six",
            [7] = "seven",
            [8] = "eight",
            [9] = "nine",
            [10] = "ten",
            [11] = "eleven",
            [13] = "thirteen",
            [14] = "fourteen",
            [15] = "quarter",
            [16] = "sixteen",
            [17] = "seventeen",
            [18] = "eighteen",
            [19] = "nineteen",
            [20] = "twenty",
            [21] = "twenty one",
            [22] = "twenty two",
            [23] = "twenty three",
            [24] = "twenty four",
            [25] = "twenty five",
            [26] = "twenty six",
            [27] = "twenty seven",
            [28] = "twenty eight",
            [29] = "twenty nine",
            [30] = "half"
        };
    }
}
