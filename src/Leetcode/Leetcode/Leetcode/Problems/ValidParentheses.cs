using System.Collections;

namespace Leetcode.Problems
{
    public static class ValidParentheses
    {
        public static bool Solve(string s)
        {
            var stack = new Stack<char>();
            var types = new Dictionary<char, char>()
            {
                ['{'] = '}',
                ['['] = ']',
                ['('] = ')'
            };

            var closings = types.Values;

            for (var i = 0; i < s.Length; i++)
            {
                if (closings.Contains(s[i]))
                {
                    if (i == 0)
                    {
                        return false;
                    }

                    var opening = stack.Pop();
                    if (types[opening] != s[i])
                    {
                        return false;
                    }

                    continue;
                }

                stack.Push(s[i]);
            }

            return stack.Count == 0;
        }
    }
}
