using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarWithoutRepetitions
{
    class VariationsWithoutRepetitionsMain
    {
        private static int resultsCount = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] result = new int[k];
            bool[] used = new bool[n + 1];

            GenVariationsWithoutRepetitions(result, n, used, 0);

            Console.WriteLine(resultsCount);
        }

        private static void GenVariationsWithoutRepetitions(int[] result, int sizeOfSet, bool[] used, int index)
        {
            if (index >= result.Length)
            {
                resultsCount++;
                Print(result);
            }
            else
            {
                for (int i = 1; i <= sizeOfSet; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        result[index] = i;
                        GenVariationsWithoutRepetitions(result, sizeOfSet, used, index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void Print(int[] result)
        {
            Console.WriteLine("{0}", string.Join(", ", result));
        }
    }
}
