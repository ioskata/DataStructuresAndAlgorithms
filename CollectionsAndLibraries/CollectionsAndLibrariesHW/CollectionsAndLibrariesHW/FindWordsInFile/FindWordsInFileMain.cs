namespace FindWordsInFile
{
    using System;
    using System.Collections.Generic;

    public class FindWordsInFileMain
    {
        private static Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            for (int r = 0; r < rows; r++)
            {
                string row = Console.ReadLine();
                string[] rowArr = row.Split(new char[] { ' ', '.', '?', '!', ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in rowArr)
                {
                    if (!wordCounts.ContainsKey(word))
                    {
                        wordCounts.Add(word, 0);
                    }

                    wordCounts[word]++;
                }
            }

            int searchedWordsCount = int.Parse(Console.ReadLine());
            string[] searchedWords = new string[searchedWordsCount];
            for (int i = 0; i < searchedWordsCount; i++)
            {
                searchedWords[i] = Console.ReadLine();
            }

            foreach (var searchedWord in searchedWords)
            {
                Console.WriteLine("{0} -> {1}", searchedWord, wordCounts[searchedWord]);
            }
        }
    }
}
