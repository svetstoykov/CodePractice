namespace Leetcode.LeetCode_75.Array_String;

public class Kids_With_the_Greatest_Number_of_Candies
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        var greatestCandyKid = candies.Max();
        var result = new bool[candies.Length];

        for (int i = 0; i < candies.Length; i++)
        {
            var currentKid =  candies[i] + extraCandies;

            result[i] = currentKid >= greatestCandyKid;
        }
        
        return result;
    }
}