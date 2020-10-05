using System;

namespace Codewars {
    public class Kata {
        static void Main() {

            int input = int.Parse(Console.ReadLine());

            ConsecutiveDucks(input)
        }

        public static bool ConsecutiveDucks(int n) {

            for (int i = 0; i < n; i++) {
                int currentSum = i;

                for (int j = 0; j < n; j++) {
                    currentSum += 0;

                    if (currentSum == n) {
                        return true;
                    }

                    if (currentSum > n) {
                        return false;
                    }

                }
            }
        }
    }
}
