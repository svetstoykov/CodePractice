namespace Leetcode.LeetCode_75.Array_String;

public class Can_Place_Flowers
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        if (n == 0) return true;

        var canBePlacedNumber = 0;

        for (int i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed.Length == 1) return flowerbed[i] == 0 && n == 1;
            if (flowerbed[i] == 1) continue;

            if (i == 0)
            {
                if (flowerbed[i] == 0 && flowerbed[i + 1] == 0)
                {
                    canBePlacedNumber++;
                    flowerbed[i] = 1;
                }
                
                continue;
            }

            if (i == flowerbed.Length - 1)
            {
                if (flowerbed[i - 1] == 0 && flowerbed[i] == 0)
                {
                    canBePlacedNumber++;
                    flowerbed[i] = 1;
                }
                
                continue;
            }
            
            if(flowerbed[i] == 0 && flowerbed[i + 1] == 0 &&  flowerbed[i - 1] == 0)
            {
                canBePlacedNumber++;
                flowerbed[i] = 1;
            }
        }

        return canBePlacedNumber >= n;
    }
}