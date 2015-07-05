namespace Task01SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    /* 01. Write a program that reads from the console a sequence of integer numbers (on a single line, separated by a space). Calculate and print the sum and average of the elements of the sequence. Keep the sequence in List<int>.*/
    class Task01SumAndAverageClass
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            string input = Console.ReadLine();
            input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(el => list.Add(int.Parse(el)));

            BigInteger sum = list.Sum();
            double average = list.Average();
            Console.WriteLine("Sum: {0}\tAverage: {1:0.000}", sum, average);
        }
    }
}
