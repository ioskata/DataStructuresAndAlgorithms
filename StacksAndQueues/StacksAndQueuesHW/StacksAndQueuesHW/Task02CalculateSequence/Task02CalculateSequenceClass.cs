namespace Task02CalculateSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Task02CalculateSequenceClass
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(n);
            for (int i = 0; i < 50; i++)
            {
                Console.Write("{0} ", queue.Peek());
                queue.Enqueue(queue.Peek() + 1);
                queue.Enqueue(queue.Peek() * 2 + 1);
                queue.Enqueue(queue.Dequeue() + 2);
            }
        }
    }
}
