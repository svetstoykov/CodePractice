using System.Linq;

namespace HackerRank.InterviewPreparationKit.DictionariesAndHashmaps
{
    public class TwoStrings
    {

        public static string GetResult(string s1, string s2)
        {
            var stringHash = s1.ToHashSet();

            for (int i = 0; i < s2.Length; i++)
            {
                if (stringHash.Contains(s2[i]))
                {
                    return "YES";
                }

            }

            return "NO";
        }

    }
}
