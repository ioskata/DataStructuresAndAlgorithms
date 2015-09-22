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

            PrintRods(source, destination, spare);
            MoveDisks(size, source, destination, spare);

            Console.WriteLine("occurencies count: {0}", occurenciesCount);
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            occurenciesCount++;
            if (bottomDisk == 1)
            {
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{occurenciesCount}: Moved disk {bottomDisk}");
                PrintRods(source, destination, spare);
            }
            else
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);

                destination.Push(source.Pop());
                Console.WriteLine($"Step #{occurenciesCount}: Moved disk {bottomDisk}");
                PrintRods(source, destination, spare);

                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }

        private static void PrintRods(Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
            Console.WriteLine();
        }
    }
}