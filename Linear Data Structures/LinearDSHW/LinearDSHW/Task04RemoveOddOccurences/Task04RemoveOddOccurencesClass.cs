namespace Task04RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using Task05OccurencesCount;

    /*04. Write a program that removes from given sequence all numbers that occur odd number of times.*/
    class Task04RemoveOddOccurencesClass
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> allOccurences = new Dictionary<int, int>();

            string input = Console.ReadLine();
            string[] inputStr = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            allOccurences = Task05OccurencesCountClass.GetOccurences(inputStr);

            StringBuilder sb = new StringBuilder();
            foreach (int key in allOccurences.Keys)
            {
                if (allOccurences[key] % 2 != 0)
                {
                    continue;
                }
                for (int i = 0; i < allOccurences[key]; i++)
                {
                    sb.Append(key);
                    sb.Append(" ");
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
