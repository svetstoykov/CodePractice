namespace Application.Problems;

public static class StringEndsWith
{
    public static bool Solve(string str, string ending)
    {
        if (ending.Length > str.Length)
        {
            return false;
        }

        str.EndsWith(ending);

        var lastEndingCharIndex = ending.Length - 1;
        
        for (var i = str.Length - 1; i > 0; i--)
        {
            if (lastEndingCharIndex < 0)
            {
                break;
            }
            
            var lastStrChar = str[i];
            var lastEndingChar = ending[lastEndingCharIndex];

            if (lastStrChar != lastEndingChar)
            {
                return false;
            }

            lastEndingCharIndex--;
        }

        return true;
    }
}