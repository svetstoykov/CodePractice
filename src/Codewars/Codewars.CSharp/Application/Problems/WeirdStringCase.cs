namespace Application.Problems;

public class WeirdStringCase
{
    public static string ToWeirdCase(string s)
        => string.Join(" ", s.Split(" ")
            .Select(w => string.Join("", w.Select((l, i)
                => i % 2 == 0
                    ? l.ToString().ToUpper()
                    : l.ToString().ToLower()))));
}