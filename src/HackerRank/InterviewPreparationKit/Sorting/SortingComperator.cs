using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.InterviewPreparationKit.Sorting
{
    public static class SortingComperator
    {
        public static void GetResult(string[] players)
        {
            var playersList = new List<Player>();


            for (int i = 0; i < players.Length; i++)
            {
                var tokens = players[i].Split(' ');

                var newPlayer = new Player()
                {
                    Name = tokens[0],
                    Score = int.Parse(tokens[1])
                };

                playersList.Add(newPlayer);
            }

            playersList.Sort(new Checker());


            Console.WriteLine(string
                .Join("\n", playersList
                    .Select(x => $"Score: {x.Score} / Name: {x.Name}")));
        }


        public class Player
        {

            public string Name { get; set; }

            public int Score { get; set; }
        }

        public class Checker : IComparer<Player>
        {
            public int Compare(Player x, Player y)
            {
                var result = y.Score.CompareTo(x.Score);

                if (result == 0)
                {
                    result = x.Name.CompareTo(y.Name);
                }

                return result;
            }
        }
    }
}



