namespace Task05OccurencesCount
{
    using System;
    using System.Collections.Generic;

    /* 05. Write a program that finds in given array of integers how many times each of them occurs. The input sequence holds numbers in range [0…1000]. The output should hold all numbers that occur at least once along with their number of occurrences.*/
    public class Task05OccurencesCountClass
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> occurences = new Dictionary<int, int>();

            string input = Console.ReadLine();
            string[] inputStr = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            occurences = GetOccurences(inputStr);
            foreach (var key in occurences.Keys)
            {
                if (occurences[key] == 1)
                {
                    Console.WriteLine("{0} -> {1} time", key, occurences[key]);
                }
                else
                {
                    Console.WriteLine("{0} -> {1} times", key, occurences[key]);
                }
            }
        }

        public static Dictionary<int, int> GetOccurences(string[] inputArr)
        {
            Dictionary<int, int> occurences = new Dictionary<int, int>();

            foreach (string numberStr in inputArr)
            {
                int number = int.Parse(numberStr);
                if (occurences.ContainsKey(number))
                {
                    occurences[number]++;
                }
                else
                {
                    occurences[number] = 1;
                }

            }

            return occurences;
        }
    }
}
