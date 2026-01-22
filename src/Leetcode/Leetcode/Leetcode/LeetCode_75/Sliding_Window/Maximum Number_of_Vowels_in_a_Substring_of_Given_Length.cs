namespace Leetcode.LeetCode_75.Sliding_Window;

public class Maximum_Number_of_Vowels_in_a_Substring_of_Given_Length
{
    public int MaxVowels(string s, int k)
    {
        var max = 0;
        for (int i = 0; i < k; i++)
        {
            if(IsVowel(s[i]))
                max++;
        }

        var window = max;
        for (int i = k; i < s.Length; i++)
        {
            if (IsVowel(s[i])) 
                window++;
            
            if(IsVowel(s[i - k]))
                window--;
            
            max = Math.Max(max, window);
        }

        return max;
    }

    private bool IsVowel(char c) => c is 'a' or 'e' or 'i' or 'o' or 'u';
}