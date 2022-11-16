namespace Application.Problems;

public class GetReadableTime
{
    public static string Solve(int seconds)
    {
        if (seconds >= 359999)
        {
            return "99:59:59";
        }

        var secondsTime = 0;
        var minutesTime = 0;
        var hoursTime = 0;
        for (int i = 0; i < seconds; i++)
        {
            secondsTime++;

            if (secondsTime == 60)
            {
                minutesTime++;
                secondsTime = 0;
            }

            if (minutesTime == 60)
            {
                hoursTime++;
                minutesTime = 0;
            }
        }

        return $"{FormatTimeAsString(hoursTime)}:{FormatTimeAsString(minutesTime)}:{FormatTimeAsString(secondsTime)}";
    }

    private static string FormatTimeAsString(int num)
    {
        if (num == 0) return "00";

        if (num < 10) return $"0{num}";

        return num.ToString();
    }
}