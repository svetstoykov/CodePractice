namespace Leetcode.LeetCode_75.Stack;

public class Asteroid_Collision
{
    public int[] AsteroidCollision(int[] asteroids)
    {
        var stack = new Stack<int>();

        foreach (var a in asteroids)
        {
            var size = Math.Abs(a);

            var shouldPush = true;
            while (stack.TryPeek(out var prev))
            {
                if (prev > 0 && a > 0) break;
                if (prev < 0 && a < 0) break;
                if (prev < 0 && a > 0) break;

                if (prev > 0 && a < 0)
                {
                    if (size > prev)
                    {
                        stack.Pop();
                    }
                    else if (prev > size)
                    {
                        shouldPush = false;
                        break;
                    }
                    else
                    {
                        stack.Pop();
                        shouldPush = false;
                        break;
                    }
                }
            }

            if (shouldPush)
                stack.Push(a);
        }

        var result = new int[stack.Count];
        for (int i = result.Length - 1; i >= 0 ; i--)
        {
            result[i] = stack.Pop();
        }
        
        return result;
    }
}