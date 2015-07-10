namespace Task08DistanceInLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class BaseLabyrinth : ILabyrinth
    {
        protected readonly string EMPTY = "0";
        protected readonly string FULL = "x";
        protected readonly string UNREACHABLE = "u";
        protected readonly string DELIMITER = " ";
        protected readonly string START = "*";

        private Cell[,] labyrinth;
        private Cell startCell;
        private HashSet<Cell> unreachable;

        public BaseLabyrinth(string[,] labyrinthStr)
        {
            this.Unreachable = new HashSet<Cell>();
            this.labyrinth = this.ParseLabyrinth(labyrinthStr);
        }

        protected virtual Cell[,] ParseLabyrinth(string[,] labyrinthStr)
        {
            var cells = new Cell[labyrinthStr.GetLength(0), labyrinthStr.GetLength(1)];
            for (int i = 0; i < labyrinthStr.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinthStr.GetLength(1); j++)
                {
                    cells[i, j] = new Cell()
                    {
                        X = i,
                        Y = j,
                        Value = labyrinthStr[i, j]
                    };

                    this.Unreachable.Add(cells[i, j]);

                    if (cells[i, j].Value == this.START)
                    {
                        this.StartCell = cells[i, j];
                    }
                }
            }

            return cells;
        }

        public Cell[,] Labyrinth
        {
            get
            {
                return this.labyrinth;
            }

            set
            {
                this.labyrinth = value;
            }
        }

        public virtual Cell StartCell
        {
            get
            {
                return this.startCell;
            }
            set
            {
                this.startCell = value;
            }
        }

        protected HashSet<Cell> Unreachable
        {
            get
            {
                return this.unreachable;
            }
            set
            {
                this.unreachable = value;
            }
        }

        public virtual void Print()
        {
            StringBuilder sbLab = new StringBuilder();
            for (int i = 0; i < this.Labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < this.Labyrinth.GetLength(1); j++)
                {
                    sbLab.AppendFormat("{0}{1}", this.Labyrinth[i, j].Value, this.DELIMITER);
                }

                sbLab.AppendLine();
            }

            Console.WriteLine(sbLab.ToString());
        }

        public abstract void CalculateDistances();
    }
}
