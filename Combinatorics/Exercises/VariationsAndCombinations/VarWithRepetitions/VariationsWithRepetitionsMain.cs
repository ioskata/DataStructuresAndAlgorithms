namespace VariationsWithRepetitions
{
    using System;

    class VariationsWithRepetitionsMain
    {
        static int resultsCount = 0;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] result = new int[k];

            GenVariationsWithRepetions(result, n);
            Console.WriteLine(resultsCount);
        }

        private static void GenVariationsWithRepetions(int[] result, int sizeOfSet, int index = 0)
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
                    result[index] = i;
                    GenVariationsWithRepetions(result, sizeOfSet, index + 1);
                }
            }
        }

        private static void Print(int[] result)
        {
            Console.WriteLine("{0}", string.Join(", ", result));
        }
    }
}
