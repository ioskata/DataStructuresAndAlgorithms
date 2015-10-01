namespace PermWithoutRepetitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class PermWithoutRepetitionsMain
    {
        private static int resultsCount = 0;

        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            var source = Enumerable.Range(1, n).ToArray();

            PermWithoutRepetitions(source, 0);

            Console.WriteLine("Total permutations: {0}", resultsCount);
        }

        private static void PermWithoutRepetitions(int[] source, int index)
        {
            if (index >= source.Length)
            {
                resultsCount++;
                Print(source);
            }
            else
            {
                for (int k = index; k < source.Length; k++)
                {
                    Swap(ref source[index], ref source[k]);
                    PermWithoutRepetitions(source, index + 1);
                    Swap(ref source[index], ref source[k]);
                }
            }
        }

        private static void Swap(ref int i, ref int k)
        {
            var temp = i;
            i = k;
            k = temp;
        }

        private static void Print(int[] result)
        {
            Console.WriteLine("{0}", string.Join(", ", result));
        }
    }
}
