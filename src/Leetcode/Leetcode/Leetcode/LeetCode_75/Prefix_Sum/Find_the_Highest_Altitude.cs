namespace Leetcode.LeetCode_75.Prefix_Sum;

public class Find_the_Highest_Altitude
{
    public int LargestAltitude(int[] gain)
    {
        var currentAtitute = 0;
        var highest = 0;
        
        for (int i = 0; i < gain.Length; i++)
        {
            
            currentAtitute += gain[i];
            
            highest = Math.Max(highest, currentAtitute);

        }
        
        return highest;
    }
}