namespace Leetcode.LeetCode_75.Array_String;

public class Reverse_Words_in_a_String
{
    public string ReverseWords(string s)
    {
        var trimmed = s.Trim();
        var words = trimmed.Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToArray();

        var result = new string[words.Length];

        var outer = 0;
        for (int i = words.Length - 1; i >= 0; i--)
        {
            result[outer] = words[i].Trim();
            
            outer++;
        }
        
        return  string.Join(" ", result);
    }
}