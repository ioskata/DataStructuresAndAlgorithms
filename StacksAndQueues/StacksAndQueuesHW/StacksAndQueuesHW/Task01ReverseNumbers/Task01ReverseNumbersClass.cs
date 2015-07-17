using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01ReverseNumbers
{
    /*Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class from .NET Framework. */
    class Task01ReverseNumbersClass
    {
        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine();
            var inputArr = inputStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>();
            foreach (var item in inputArr)
            {
                stack.Push(item);
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in stack)
            {
                sb.AppendFormat("{0} ", item);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
