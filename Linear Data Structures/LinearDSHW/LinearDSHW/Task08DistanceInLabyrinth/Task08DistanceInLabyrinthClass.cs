namespace Task08DistanceInLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Task08DistanceInLabyrinthClass
    {
        static void Main(string[] args)
        {
            string[,] input = 
        {
            {"0", "0", "0", "x", "0", "x"},
            {"0", "x", "0", "x", "0", "x"},
            {"0", "*", "x", "0", "x", "0"},
            {"0", "x", "0", "0", "0", "0"},
            {"0", "0", "0", "x", "x", "0"},
            {"0", "0", "0", "x", "0", "x"},
        };
            ILabyrinth labyrinth = new LabyrinthBFSQueue(input);

            labyrinth.CalculateDistances();
            labyrinth.Print();
        }
    }
}
