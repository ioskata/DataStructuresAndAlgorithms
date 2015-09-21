namespace ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ConnectedAreasInMatrixMain
    {
        static SortedSet<ConnectedArea> areas = new SortedSet<ConnectedArea>();
        //static char[,] layout = new char[,]
        //{
        //    {' ', ' ', ' ', '*',' ', ' ' , ' ','*', ' ' },
        //    {' ', ' ', ' ', '*',' ', ' ' , ' ','*', ' ' },
        //    {' ', ' ', ' ', '*',' ', ' ' , ' ','*', ' ' },
        //    {' ', ' ', ' ', ' ','*', ' ' , '*',' ', ' ' }
        //};

        static char[,] layout = new char[,]
       {
            {'*', ' ', ' ', '*',' ', ' ' , ' ','*', ' ', ' ' },
            {'*', ' ', ' ', '*',' ', ' ' , ' ','*', ' ', ' ' },
            {'*', ' ', ' ', '*','*', '*' , '*','*', ' ', ' ' },
            {'*', ' ', ' ', '*',' ', ' ' , ' ','*', ' ', ' ' },
            {'*', ' ', ' ', '*',' ', ' ' , ' ','*', ' ', ' ' },
       };

        static void Main(string[] args)
        {
            int[] startPoint = FindConnectedArea();
            while (null != startPoint)
            {
                ConnectedArea newArea = new ConnectedArea()
                {
                    Row = startPoint[0],
                    Column = startPoint[1]
                };

                FindConnectedCells(startPoint[0], startPoint[1], newArea);

                areas.Add(newArea);
                startPoint = FindConnectedArea();
            }

            PrintAreas(areas);
        }

        private static void PrintAreas(SortedSet<ConnectedArea> areas)
        {
            Console.WriteLine("Total areas found: {0}", areas.Count);
            int areasCounter = 0;
            foreach (var area in areas)
            {
                areasCounter++;
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", areasCounter, area.Row, area.Column, area.Size);
            }
        }

        private static int[] FindConnectedArea()
        {
            int[] areaStart = new int[2];
            for (int row = 0; row < layout.GetLength(0); row++)
            {
                for (int col = 0; col < layout.GetLength(1); col++)
                {
                    if (layout[row, col] == ' ')
                    {
                        areaStart[0] = row;
                        areaStart[1] = col;
                        return areaStart;
                    }
                }
            }

            return null;
        }

        private static void FindConnectedCells(int row, int col, ConnectedArea newArea)
        {
            if (IsOutside(row, col))
            {
                return;
            }

            if (layout[row, col] == '*')
            {
                return;
            }

            if (IsVisited(row, col))
            {
                return;
            }

            newArea.Size++;
            MarkVisited(row, col);

            FindConnectedCells(row, col + 1, newArea);
            FindConnectedCells(row + 1, col, newArea);
            FindConnectedCells(row - 1, col, newArea);
            FindConnectedCells(row, col - 1, newArea);
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 || row > layout.GetLength(0) - 1 || col < 0 || col > layout.GetLength(1) - 1;
        }

        private static bool IsVisited(int row, int col)
        {
            return layout[row, col] == 'v';
        }

        private static void MarkVisited(int row, int col)
        {
            layout[row, col] = 'v';
        }
    }
}
