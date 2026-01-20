namespace Leetcode.LeetCode_75.Two_Pointer;

public class Is_Subsequence
{
    public bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0) return true;

        var pointerForS = 0;

        for (int i = 0; i < t.Length; i++)
        {
            if (pointerForS < s.Length && s[pointerForS] == t[i])
            {
                pointerForS++;
            }
        }

        return pointerForS == s.Length;
    }
}