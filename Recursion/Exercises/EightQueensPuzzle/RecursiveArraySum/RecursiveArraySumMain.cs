namespace RecursiveArraySum
{
    using System;

    public class RecursiveArraySumMain
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 7, 6, 45, -13, 0, -13, 7 };
            Console.WriteLine(FindSum(array, 0));
        }

        private static int FindSum(int[] array, int index)
        {
            if (index == array.Length)
            {
                return 0;
            }

            return array[index] + FindSum(array, index + 1);
        }
    }
}
