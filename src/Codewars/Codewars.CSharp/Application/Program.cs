using System.Diagnostics;
using Application;
using Application.Problems;

var random = new Random();


for (int j = 0; j < 5; j++)
{
    var nums = new List<int>();

    for (int i = 0; i < 5_000_000; i++)
    {
        nums.Add(random.Next(1, 1000));
    }

    var arrayNums = nums.ToArray();
    var stopwatch = new Stopwatch();
    stopwatch.Start();

    MovingZerosToTheEnd.MoveZeroes(arrayNums);

    Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}");
}