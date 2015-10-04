namespace PermWithoutRepetitionsiterative
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class PermWithoutRepetitionsiterativeMain
    {
        static void Main(string[] args)
        {
            object[] array = new object[] { 1, 2, 3, 4 };
            int n = array.Length;
            int[] p = Enumerable.Range(0, n + 1).ToArray();
            int resultsCount = 0;

            Print(array);
            resultsCount++;

            int i = 1;
            while (i < n)
            {
                p[i]--;
                int j = 0;
                if (i % 2 != 0)
                {
                    j = p[i];
                }

                Swap(ref array[j], ref array[i]);
                i = 1;
                while (p[i] == 0)
                {
                    p[i] = i;
                    i++;
                }

                Print(array);
                resultsCount++;
            }

            Console.WriteLine("Total permutations: {0}", resultsCount);
        }

        private static void Swap(ref object v1, ref object v2)
        {
            object temp = v1;
            v1 = v2;
            v2 = temp;
        }

        private static void Print(object[] result)
        {
            Console.WriteLine("{0}", string.Join(", ", result));
        }
    }
}
