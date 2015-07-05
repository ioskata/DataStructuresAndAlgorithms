namespace Task03LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /* 03. Write a method that finds the longest subsequence of equal numbers in given List<int> and returns the result as new List<int>. If several sequences has the same longest length, return the leftmost of them. Write a program to test whether the method works correctly. */
    class Task03LongestSubsequenceClass
    {
        static void Main(string[] args)
        {
            List<int> inputList = new List<int>();
            string input = Console.ReadLine();
            input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(el => inputList.Add(int.Parse(el)));

            List<int> resultList = GetLeftMostLonguestSequence(inputList);

            resultList.ForEach(el => Console.Write(el + " "));
            Console.WriteLine();
        }

        private static List<int> GetLeftMostLonguestSequence(List<int> input)
        {
            int count = 1;
            int maxCount = 1;
            int number = input[0];

            List<int> result = new List<int>(input.Count);

            for (int i = 1; i < input.Count; i++)
            {
                if (input[i] == input[i - 1])
                {
                    count++;
                    if (count > maxCount)
                    {
                        maxCount = count;
                        number = input[i];
                    }
                }
                else
                {
                    count = 1;
                }
            }

            // return Enumerable.Repeat(number, maxCount).ToList(); // slow but fast written solution
            for (int i = 0; i < maxCount; i++)
            {
                result.Add(number);
            }

            return result;
        }
    }
}
