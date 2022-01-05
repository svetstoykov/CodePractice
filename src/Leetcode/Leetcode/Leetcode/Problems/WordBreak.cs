namespace Leetcode.Problems
{
    public static class WordBreak
    {
        public static bool Solve(string s, IList<string> wordDict)
        {
            var tempWord = string.Empty;

            foreach (var word in s)
            {
                tempWord += word;

                if (wordDict.Contains(tempWord))
                {
                    tempWord = tempWord.Replace(tempWord, "");
                }
            }

            return tempWord.Length == 0;
        }
    }
}
