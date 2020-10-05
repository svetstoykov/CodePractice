namespace HackerRank.InterviewPreparationKit.StringManipulation
{
    public static class AlternatingCharacters
    {
        public static int GetResult(string s)
        {
            var removals = 0;

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    removals++;
                }
            }

            return removals;
        }
    }
}
