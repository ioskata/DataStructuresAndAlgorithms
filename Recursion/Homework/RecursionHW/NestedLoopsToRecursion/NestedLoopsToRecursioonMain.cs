namespace NestedLoopsToRecursion
{
    using System;

    class NestedLoopsToRecursioonMain
    {
        static int n = 0;
        static int iterationsCount = 0;

        static void Main(string[] args)
        {
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];

            Generate(n - 1, vector);
            Console.WriteLine("Iterations count: {0}", iterationsCount);
        }

        private static void Generate(int index, int[] vector)
        {
            if (index < 0)
            {
                Print(vector);
            }
            else
            {
                for (int i = 1; i < n + 1; i++)
                {
                    vector[index] = i;
                    Generate(index - 1, vector);
                }
            }
        }

        private static void Print(int[] vector)
        {
            iterationsCount++;
            for (int i = vector.Length - 1; i >= 0; i--)
            {
                Console.Write("{0} ", vector[i]);
            }

            Console.WriteLine();
        }
    }
}
