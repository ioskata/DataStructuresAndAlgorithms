namespace CombinationsWithoutRepetitions
{
    using System;
    using System.Linq;

    class CombinationsWithoutRepetitionsMain
    {
        static int n = 0;
        static int k = 0;
        static int combinationsCount = 0;

        static void Main(string[] args)
        {
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            k = int.Parse(Console.ReadLine());

            int[] vector = new int[k];
            //int[] elements = new int[n];
            var elements = Enumerable.Range(1, n).ToArray();

            GenerateCombWithoutRepetitions(0, vector, elements, 0);

            Console.WriteLine("Combinations count: {0}", combinationsCount);
        }

        private static void GenerateCombWithoutRepetitions(int vectorIndex, int[] vector, int[] elements, int elementsIndex)
        {
            if (vectorIndex == k)
            {
                Print(vector, elements);
                return;
            }

            for (int i = elementsIndex; i < n; i++)
            {
                vector[vectorIndex] = i;
                GenerateCombWithoutRepetitions(vectorIndex + 1, vector, elements, i + 1);
            }
        }

        private static void Print(int[] vector, int[] elements)
        {
            combinationsCount++;
            for (int i = vector.Length - 1; i >= 0; i--)
            {
                Console.Write("{0} ", elements[vector[i]]);
            }

            Console.WriteLine();
        }
    }
}
