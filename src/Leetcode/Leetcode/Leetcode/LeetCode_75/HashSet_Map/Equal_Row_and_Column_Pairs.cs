namespace Leetcode.LeetCode_75.HashSet_Map;

public class Equal_Row_and_Column_Pairs
{
    public int EqualPairs(int[][] grid)
    {
        var map = new Dictionary<string, int>();
        var n = grid.Length;
        var matching = 0;

        for (int i = 0; i < n; i++)
        {
            var row = string.Join(",", grid[i]);
            map[row] = map.GetValueOrDefault(row, 0) + 1;
        }

        for (int col = 0; col < n; col++)
        {
            var column = new int[n];
            for (int row = 0; row < n; row++)
            {
                column[row] = grid[row][col];
            }

            var colString = string.Join(",", column);
            if (map.TryGetValue(colString, out var count))
            {
                matching += count;
            }
        }

        return matching;
    }
}