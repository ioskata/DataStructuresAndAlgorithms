namespace CombWithRepetitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class CombWithRepetitionsMain
    {
        private static int resultsCount = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] result = new int[k];

            GenCombWithRepetitions(result, n, 0, 1);

            Console.WriteLine(resultsCount);
        }

        private static void GenCombWithRepetitions(int[] result, int sizeOfSet, int index, int start)
        {
            if (index >= result.Length)
            {
                resultsCount++;
                Print(result);
            }
            else
            {
                for (int i = start; i <= sizeOfSet; i++)
                {
                    result[index] = i;
                    GenCombWithRepetitions(result, sizeOfSet, index + 1, i);
                }
            }
        }

        private static void Print(int[] result)
        {
            Console.WriteLine("{0}", string.Join(", ", result));
        }
    }
}
