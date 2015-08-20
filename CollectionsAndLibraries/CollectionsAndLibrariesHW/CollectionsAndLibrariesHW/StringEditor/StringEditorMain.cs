namespace StringEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class StringEditorMain
    {
        static BigList<char> text = new BigList<char>();
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputArr;
            while (input.ToUpper() != "END")
            {
                string upperInput = input.ToUpper();
                try
                {
                    if (upperInput.Trim().StartsWith("INSERT"))
                    {
                        inputArr = ParseInput(input);
                        Insert(inputArr[1], int.Parse(inputArr[2]));
                    }

                    if (upperInput.Trim().StartsWith("APPEND"))
                    {

                        inputArr = ParseInput(input);
                        Append(inputArr[1]);
                    }

                    if (upperInput.Trim().StartsWith("DELETE"))
                    {

                        inputArr = ParseInput(input);
                        Delete(int.Parse(inputArr[1]), int.Parse(inputArr[2]));
                    }

                    if (upperInput.Trim().StartsWith("REPLACE"))
                    {
                        inputArr = ParseInput(input);
                        Replace(int.Parse(inputArr[1]), int.Parse(inputArr[2]), inputArr[3]);
                    }

                    if (upperInput.Trim().StartsWith("PRINT"))
                    {
                        Print();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR");
                }

                input = Console.ReadLine();
            }
        }

        private static string[] ParseInput(string input)
        {
            string[] inputArr = input.Split(new char[] { ' ' });
            return inputArr;
        }

        private static void Insert(string newText, int position)
        {
            text.InsertRange(position, newText);
        }

        private static void Append(string newText)
        {
            text.AddRange(newText);
        }

        private static void Delete(int startIndex, int count)
        {
            text.RemoveRange(startIndex, count);
        }

        private static void Replace(int startIndex, int count, string newText)
        {
            text.RemoveRange(startIndex, count);
            text.InsertRange(startIndex, newText);
        }

        private static void Print()
        {
            foreach (var ch in text)
            {
                Console.Write(ch);
            }

            Console.WriteLine();
        }
    }
}
