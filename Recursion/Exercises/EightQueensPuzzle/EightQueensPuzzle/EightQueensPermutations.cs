namespace EightQueensPuzzle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EightQueensPermutations
    {
        private const int Size = 8;

        public static void Enumerate(int[] arr, int n)
        {
            if (n == arr.Length)
            {
                PrintQueens(arr);
            }
            else
            {
                for (int i = 0; i < Size; i++)
                {
                    arr[n] = i;
                    if (IsConsistent(arr, n))
                    {
                        Enumerate(arr, n + 1);
                    }
                }
            }
        }

        private static bool IsConsistent(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == arr[n] || arr[i] - arr[n] == (n - i) || arr[n] - arr[i] == (n - i))
                {
                    return false;
                }
            }

            return true;
        }

        private static void PrintQueens(int[] arr)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (arr[i] == j)
                    {
                        Console.Write("Q ");
                    }
                    else
                    {
                        Console.Write("* ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
