namespace Leetcode.Others;

public class RandomProvider
{
    private readonly Dictionary<int, int> _hashSet = [];
    private readonly List<int> _nums = [];

    public void Insert(int num)
    {
        var hash = num.GetHashCode();
        
        if (!this._hashSet.TryAdd(hash, num)) return;

        this._nums.Add(num);
    }

    public void Remove(int num)
    {
        var hash = num.GetHashCode();

        this._hashSet.Remove(hash);
        this._nums.Remove(num);
    }

    public int GetRandomValue()
    {
        return this._nums[new Random().Next(this._nums.Count)];
    }
}