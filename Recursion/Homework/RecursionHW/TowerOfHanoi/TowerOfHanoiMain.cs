namespace TowerOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TowerOfHanoiMain
    {
        static int occurenciesCount = 0;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            Stack<int> source = new Stack<int>(Enumerable.Range(1, size).Reverse());
            Stack<int> destination = new Stack<int>();
            Stack<int> spare = new Stack<int>();

            MoveDisks(size, source, destination, spare);

            Console.WriteLine("occurencies count: {0}", occurenciesCount);
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            occurenciesCount++;
            if (bottomDisk == 1)
            {
                destination.Push(source.Pop());
            }
            else
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);
                destination.Push(source.Pop());
                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }
    }
}
