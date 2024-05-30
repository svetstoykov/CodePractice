namespace Application.Problems;

public class MovingZerosToTheEnd
{
    public static int[] MoveZeroes(int[] arr)
    {
        var result = new int[arr.Length];
        var numbersStartingIndex = 0;
        
        foreach (var currentNum in arr)
        {
            if (currentNum == default)
            {
                continue;
            };
            
            result[numbersStartingIndex] = currentNum;
            numbersStartingIndex++;
        }

        return result;
    }
}