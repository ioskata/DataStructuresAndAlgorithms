namespace PermutationsWithRepetitionsFast
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PermutationsWithRepetitionsFastMain
    {
        static void Main(string[] args)
        {
           // var arr = new int[] { 1, 3, 5, 5 };
            var arr = new int[]  { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 } ;
            GeneratePermutations(arr, 0);
        }

        static void GeneratePermutations(int[] arr, int k)
        {
            if (k >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                var swapped = new HashSet<int>();
                for (int i = k; i < arr.Length; i++)
                {
                    if (!swapped.Contains(arr[i]))
                    {
                        Swap(ref arr[k], ref arr[i]);
                        GeneratePermutations(arr, k + 1);
                        Swap(ref arr[k], ref arr[i]);

                        swapped.Add(arr[i]);
                    }
                }
            }
        }

        static void Print<T>(T[] arr)
        {
            Console.WriteLine("(" + string.Join(", ", arr) + ")");
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
