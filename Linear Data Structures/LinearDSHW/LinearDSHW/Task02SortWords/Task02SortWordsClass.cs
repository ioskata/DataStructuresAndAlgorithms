namespace Task02SortWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /* 02. Write a program that reads from the console a sequence of words (strings on a single line, separated by a space). Sort them alphabetically. Keep the sequence in List<string>.*/
    class Task02SortWordsClass
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string input = Console.ReadLine();
            list = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            list.Sort();
            list.ForEach(el => Console.Write(el + " "));
            Console.WriteLine();
        }
    }
}
