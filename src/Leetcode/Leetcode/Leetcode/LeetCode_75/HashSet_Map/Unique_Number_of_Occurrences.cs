namespace Leetcode.LeetCode_75.HashSet_Map;

public class Unique_Number_of_Occurrences
{
    public bool UniqueOccurrences(int[] arr)
    {
        var map = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            if (map.TryGetValue(arr[i], out var count))
            {
                map[arr[i]] = count + 1;
                continue;
            }
            
            map.Add(arr[i], 1);
        }
        
        return map.Count == new HashSet<int>(map.Values).Count;
    }
}