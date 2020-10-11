using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.ProblemSolving
{
    public class BiggerIsGreater
    {

        // MY SOLUTION => works with up to 9 chars

        public static string biggerIsGreater(string w)
        {
            var word = w.ToCharArray();
            var collection = new List<string>();

            Permute(0, word,w, collection);

            return collection.Count == 0 
                ? "no answer" 
                : collection.OrderBy(c => c).ToArray()[0];
        }
        public static void Permute(int index, char[] word, string w, List<string> collection)
        {

            if (index == word.Length)
            {
                var currentWord = string.Join("", word);

                if (string
                    .Compare(w, currentWord, StringComparison.InvariantCulture) == -1)
                {
                    collection.Add(currentWord);
                }
            }
            else
            {
                Permute(index + 1, word, w, collection);
                for (int i = index + 1; i < word.Length; i++)
                {
                    Swap(index, i, word);
                    Permute(index + 1, word, w, collection);
                    Swap(index, i, word);
                }
            }


        }
        public static void Swap(int index, int i, char[] word)
        {
            var temp = word[i];
            word[i] = word[index];
            word[index] = temp;
        }
    }
}
