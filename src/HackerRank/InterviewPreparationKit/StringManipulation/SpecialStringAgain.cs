namespace HackerRank.InterviewPreparationKit.StringManipulation
{
    public static class SpecialStringAgain
    {
        public static long GetResult(int n, string s)
        {

            long retVal = s.Length;

            for (int i = 0; i < s.Length; i++)
            {
                var startChar = s[i];
                int diffCharIdx = -1;
                for (int j = i + 1; j < s.Length; j++)
                {
                    var currChar = s[j];
                    if (startChar == currChar)
                    {
                        if ((diffCharIdx == -1) ||
                            (j - diffCharIdx) == (diffCharIdx - i))
                            retVal++;
                    }
                    else
                    {
                        if (diffCharIdx == -1)
                            diffCharIdx = j;
                        else
                            break;
                    }
                }
            }
            return retVal;

        }
    }
}
