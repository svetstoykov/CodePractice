namespace Leetcode.LeetCode_75.Two_Pointer;

public class Container_With_Most_Water
{
    public int MaxArea(int[] height)
    {
        var a = 0;
        var b = height.Length - 1;
        var maxArea = 0;

        while (a < b)
        {
            var aValue =  height[a];
            var bValue =  height[b];
            
            var width = b - a;
            var wall = aValue > bValue ? bValue : aValue;

            if (maxArea < width * wall)
            {
                maxArea = width * wall;
            }

            if (aValue > bValue)
            {
                b--;
            }
            else
            {
                a++;
            }
        }
        
        return maxArea;
    }
}