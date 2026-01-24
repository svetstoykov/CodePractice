namespace Leetcode.LeetCode_75.Queue;

public class RecentCounter
{
    private readonly Queue<int> _queue;
    private const int WindowInMs = 3000;
    
    public RecentCounter()
    {
        this._queue = new Queue<int>();
    }

    public int Ping(int t)
    {
        this._queue.Enqueue(t);

        var window = t - WindowInMs;
        
        while (_queue.Peek() < window) _queue.Dequeue();

        return this._queue.Count;
    }
}