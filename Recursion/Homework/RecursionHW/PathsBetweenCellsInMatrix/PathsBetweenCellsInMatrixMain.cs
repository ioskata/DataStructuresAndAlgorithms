namespace PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;

    class PathsBetweenCellsInMatrixMain
    {
        static int pathsCount = 0;
        static int[] startCell = new int[2];
        static List<char> path = new List<char>();
        static char[,] lab = new char[,]
        {
            { 's', ' ', ' ', ' ' },
            { ' ', '*', '*', ' ' },
            { ' ', '*', '*', ' ' },
            { ' ', '*', 'e', ' ' },
            { ' ', ' ', ' ', ' ' },
        };

        static void Main(string[] args)
        {
            try
            {
                startCell = FindStart();
            }
            catch (InvalidOperationException ioex)
            {
                Console.WriteLine(ioex.Message);
            }

            FindPathToExit(startCell[0], startCell[1], 'S');

            Console.WriteLine("Total paths found: {0}", pathsCount);
        }

        private static void FindPathToExit(int row, int col, char direction)
        {
            if (IsOutside(row, col))
            {
                return;
            }

            if (IsVisited(row, col))
            {
                return;
            }

            if (lab[row, col] == 'e')
            {
                pathsCount++;
                PrintPath(path, direction);
                return;
            }

            path.Add(direction);
            MarkVisitedCell(row, col);

            FindPathToExit(row + 1, col, 'D');
            FindPathToExit(row - 1, col, 'U');
            FindPathToExit(row, col + 1, 'R');
            FindPathToExit(row, col - 1, 'L');

            UnmarkVisitedCell(row, col);
            path.RemoveAt(path.Count - 1);
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 || row > lab.GetLength(0) - 1 || col < 0 || col > lab.GetLength(1) - 1 || lab[row, col] == '*';
        }

        private static bool IsVisited(int row, int col)
        {
            return lab[row, col] == 'v';
        }

        private static void UnmarkVisitedCell(int row, int col)
        {
            lab[row, col] = ' ';
        }

        private static void MarkVisitedCell(int row, int col)
        {
            lab[row, col] = 'v';
        }

        private static void PrintPath(List<char> path, char direction)
        {
            Console.WriteLine(string.Join(string.Empty, path) + direction);
        }

        private static int[] FindStart()
        {
            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    if (lab[row, col] == 's')
                    {
                        return new int[] { row, col };
                    }
                }
            }

            throw new InvalidOperationException("Failed to find the starting cell.");
        }
    }
}
