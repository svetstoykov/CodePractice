namespace Leetcode.LeetCode_75.Array_String;

public class Greatest_Common_Divisor_of_Strings
{
    public string GcdOfStrings(string str1, string str2)
    {
        if (str1 + str2 != str2 + str1) return "";
    
        var gcd = GCD(str1.Length, str2.Length);
        return str1.Substring(0, gcd);
    }

    private int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
}