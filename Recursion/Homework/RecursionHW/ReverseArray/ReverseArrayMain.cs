namespace ReverseArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ReverseArrayMain
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Reverse(arr, 0);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }

        private static void Reverse(int[] arr, int index)
        {
            if (arr.Length / 2 == index)
            {
                return;
            }

            int temp = arr[index];
            arr[index] = arr[arr.Length - 1 - index];
            arr[arr.Length - 1 - index] = temp;
            Reverse(arr, index + 1);
        }
    }
}
