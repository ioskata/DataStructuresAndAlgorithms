namespace SubsetOfStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SubsetOfStringsMain
    {
        private static string Separator = ", ";

        static void Main(string[] args)
        {
            Console.WriteLine($"Insert the strings separated by {Separator}");
            string[] inputArr = Console.ReadLine().Split(new string[] { Separator}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Console.WriteLine("k = ");
            int k = int.Parse(Console.ReadLine());
            int[] result = new int[k];
            GenCombinationsWithoutRepetitions(result, inputArr, 0, 0);
        }

        private static void GenCombinationsWithoutRepetitions(int[] result, string[] inputArr, int resultIndex, int elementIndex)
        {
            if (resultIndex >= result.Length)
            {
                Print(result, inputArr);
                return;
            }

            for (int i = elementIndex; i < inputArr.Length; i++)
            {
                result[resultIndex] = i;
                GenCombinationsWithoutRepetitions(result, inputArr, resultIndex + 1 , i + 1);
            }
        }

        private static void Print(int[] result, string[] inputArr)
        {
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write($"{inputArr[result[i]]} ");
            }

            Console.WriteLine();
        }
    }
}
