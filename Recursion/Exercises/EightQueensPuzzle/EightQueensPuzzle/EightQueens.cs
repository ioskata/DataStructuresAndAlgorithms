namespace EightQueensPuzzle
{
    using System;
    using System.Collections.Generic;

    public class EightQueens
    {
        const int Size = 8;
        static bool[,] chessboard = new bool[Size, Size];
        static int solutionsFound = 0;

        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedColumns = new HashSet<int>();
        static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        public static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (chessboard[row, col])
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('_');
                    }
                }
                Console.WriteLine();
            }

            solutionsFound++;
            Console.WriteLine("solution number {0}", solutionsFound);
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            bool positionOccupied = attackedColumns.Contains(col) ||
                 attackedRows.Contains(row) ||
                 attackedLeftDiagonals.Contains(col - row) ||
                 attackedRightDiagonals.Contains(col + row);
            return !positionOccupied;
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Add(row);
            attackedColumns.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(col + row);
            chessboard[row, col] = true;
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Remove(row);
            attackedColumns.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(col + row);
            chessboard[row, col] = false;
        }
    }
}