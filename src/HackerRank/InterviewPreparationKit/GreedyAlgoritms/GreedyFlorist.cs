using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.InterviewPreparationKit.GreedyAlgoritms
{
    public static class GreedyFlorist
    {

        public static int GetResult(int k, int[] c)
        {
            var flowersArranged = c.OrderByDescending(c => c).ToList();
            var peopleQueue = new Queue<Customer>();
            var totalPrice = 0;

            for (int i = 0; i < k; i++)
            {
                var customer = new Customer();

                peopleQueue.Enqueue(customer);
            }

            foreach (var flower in flowersArranged)
            {
                var currentGuy = peopleQueue.Dequeue();

                totalPrice += currentGuy.BuyFlower(flower);

                peopleQueue.Enqueue(currentGuy);
            }

            return totalPrice;
        }

        public class Customer
        {
            public int FlowersBought { get; set; }

            public int BuyFlower(int flowerPrice)
            {
                var price = (this.FlowersBought + 1) * flowerPrice;
                this.FlowersBought++;

                return price;
            }
        }


        public static int GetResult2(int k, int[] c)
        {
            int n = c.Length;
            int minCost = 0;
            int tempCount = 0;
            int previousPurchases = 0;

            Array.Sort(c);

            if (k >= n)
            {
                for (int i = 0; i < n; i++)
                    minCost += c[i];
            }
            else
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    if (tempCount == k)
                    {
                        tempCount = 0;
                        previousPurchases++;
                    }
                    minCost += (previousPurchases + 1) * c[i];
                    tempCount++;
                }
            }

            return minCost;
        }
    }
}
