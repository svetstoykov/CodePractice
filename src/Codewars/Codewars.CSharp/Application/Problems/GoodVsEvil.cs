namespace Application.Problems;

public class GoodVsEvil
{
    public static string Solve(string good, string evil)
    {
        var goods = new[] {1, 2, 3, 3, 4, 10};
        var bads = new[] {1, 2, 2, 2, 3, 5, 10};

        var goodsSum = good
            .Split(" ")
            .Select((g, i) => goods[i] * int.Parse(g))
            .Sum();

        var badsSum = evil
            .Split(" ")
            .Select((b, i) => bads[i] * int.Parse(b))
            .Sum();


        if (goodsSum == badsSum)
        {
            return "Battle Result: No victor on this battle field";
        }

        return goodsSum > badsSum
            ? "Battle Result: Good triumphs over Evil"
            : "Battle Result: Evil eradicates all trace of Good";
    }
}