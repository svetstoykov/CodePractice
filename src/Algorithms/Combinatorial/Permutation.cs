using System;
using System.Text;

namespace Algorithms.Combinatorial
{
    public class Permutation
    {
        private readonly int[] _elements;
        private readonly bool[] _used;
        private readonly int[] _permutation;
        private StringBuilder _sb;
        public Permutation(int[] arr)
        {
            this._elements = arr;
            this._used = new bool[arr.Length];
            this._permutation= new int[arr.Length];
            this._sb = new StringBuilder();
        }

        public void PermuteWithHelpers(int index)
        {
            if(index >= _elements.Length)
            {
                Console.WriteLine(string.Join(' ', this._permutation));
            }
            else
            {
                for (int i = 0; i < this._elements.Length; i++)
                {
                    if (!_used[i])
                    {
                        this._used[i] = true;
                        this._permutation[index] = this._elements[i];
                        PermuteWithHelpers(index + 1);
                        this._used[i] = false;
                    }

                }
            }
        }

        public void PermuteWithSwap(int index)
        {
            if (index >= _elements.Length)
            {
                Console.WriteLine(string.Join(' ', this._elements));
            }
            else
            {
                PermuteWithSwap(index + 1);
                for (int i = index + 1; i < _elements.Length; i++)
                {
                    Swap(index, i);
                    PermuteWithSwap(index + 1);
                    Swap(index,i);
                }
            }
        }

        private void Swap(int index, int i)
        {
            var temp = this._elements[i];
            this._elements[i] = this._elements[index];
            this._elements[index] = temp;
        }
    }
}
