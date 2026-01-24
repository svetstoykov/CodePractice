using System.Text;

namespace Leetcode.LeetCode_75.Stack;

public class Decode_String
{
    public string DecodeString(string s)
    {
        var numStack = new Stack<int>();
        var stringStack = new Stack<string>();
        
        var currentString = string.Empty;
        var multiplier = string.Empty;
        
        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            
            if (c == '[')
            {
                stringStack.Push(currentString);
                numStack.Push(int.Parse(multiplier));
                currentString = string.Empty;
                multiplier = string.Empty; 
                continue;
            }
            
            if (char.IsDigit(c))
            {
                multiplier += c;
                continue;
            }

            if (c == ']')
            {
                var count = numStack.Pop();
                var prevString = stringStack.Pop();
                
                var repeated = new StringBuilder();
                for (int j = 0; j < count; j++)
                {
                    repeated.Append(currentString);  
                }
                
                currentString = prevString + repeated;  
                continue;
            }

            currentString += c;
        }
        
        return currentString;
    }
}