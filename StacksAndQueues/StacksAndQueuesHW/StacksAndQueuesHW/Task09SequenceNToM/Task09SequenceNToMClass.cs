using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task09SequenceNToM
{
    class Task09SequenceNToMClass
    {
        static void Main(string[] args)
        {
            string[] inputArr = (Console.ReadLine()).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(inputArr[0]);
            int m = int.Parse(inputArr[1]);
            if (m <= n)
            {
                Console.WriteLine("(no solution)");
                return;
            }

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(m);
            while (m / 2 >= n)
            {
                if (m % 2 != 0)
                {
                    m = m - 1;
                    queue.Enqueue(m);
                    continue;
                }

                m = m / 2;
                queue.Enqueue(m);
            }

            while (m - 2 >= n)
            {
                m = m - 2;
                queue.Enqueue(m);
            }

            while (m - 1 >= n)
            {
                m = m - 1;
                queue.Enqueue(m);
            }

            foreach (var item in queue)
            {
                Console.Write("{0} ", item);
            }

        }
    }
}
