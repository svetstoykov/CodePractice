namespace Leetcode.LeetCode_75.Array_String;

public class Reverse_Vowels
{
    public string ReverseVowels(string s)
    {
        HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u'];

        var chars = s.ToCharArray();
        var startIndex = 0;
        var endIndex = s.Length - 1;
        while (startIndex < endIndex)
        {
            var lowerStartChar = char.ToLower(chars[startIndex]);
            var upperStartChar = char.ToLower(chars[endIndex]);

            if (vowels.Contains(lowerStartChar))
            {
                if (vowels.Contains(upperStartChar))
                {
                    var temp = chars[startIndex];
                    chars[startIndex] = chars[endIndex];
                    chars[endIndex] = temp;

                    startIndex++;
                }

                endIndex--;
                continue;
            }

            if (vowels.Contains(upperStartChar))
            {
                if (vowels.Contains(lowerStartChar))
                {
                    var temp = chars[startIndex];
                    chars[startIndex] = chars[endIndex];
                    chars[endIndex] = temp;
                    
                    endIndex--;
                }
                
                startIndex++;
                continue;
            }

            startIndex++;
            endIndex--;
        }

        return string.Join("", chars);
    }
}