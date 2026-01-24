namespace Leetcode.LeetCode_75.Stack;

public class Removing_Stars_From_String
{
    public string RemoveStars(string s)
    {
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (c == '*')
            {
                stack.Pop();
            }
            else
            {
                stack.Push(c);
            }
        }

        var result = new char[stack.Count];
        var index = stack.Count - 1;
        while (stack.TryPop(out var c))
        {
            result[index] = c;
            index--;
        }
        
        return new string(result);
    }
}