namespace Application.Problems;

public static class IsPrime
{
    public static bool Solve(int n)
    {
        if (n <= 2 || n % 2 == 0)
        {
            return n == 2;
        }

        for (var i = 3; i <= Math.Sqrt(n); i += 2)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        
        return true;
    }
}