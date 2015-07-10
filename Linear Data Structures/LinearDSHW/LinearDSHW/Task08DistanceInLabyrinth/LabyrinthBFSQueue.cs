namespace Task08DistanceInLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LabyrinthBFSQueue : BaseLabyrinth
    {
        public LabyrinthBFSQueue(string[,] labyrinthStr)
            : base(labyrinthStr)
        {
        }

        public override void CalculateDistances()
        {
            Queue<Cell> queue = new Queue<Cell>();
            queue.Enqueue(this.StartCell);

            int step = 1;
            while (queue.Count > 0)
            {
                var current = queue.Peek();
                int.TryParse(current.Value, out step);
                step++;

                int left = current.Y - 1;
                int right = current.Y + 1;
                int above = current.X - 1;
                int below = current.X + 1;

                if (left >= 0)
                {
                    if (this.Labyrinth[current.X, left].Value == this.EMPTY)
                    {
                        this.Labyrinth[current.X, left].Value = step.ToString();
                        queue.Enqueue(this.Labyrinth[current.X, left]);
                    }
                }

                if (above >= 0)
                {
                    if (this.Labyrinth[above, current.Y].Value == this.EMPTY)
                    {
                        this.Labyrinth[above, current.Y].Value = step.ToString();
                        queue.Enqueue(this.Labyrinth[above, current.Y]);
                    }
                }

                if (right < this.Labyrinth.GetLength(1))
                {
                    if (this.Labyrinth[current.X, right].Value == this.EMPTY)
                    {
                        this.Labyrinth[current.X, right].Value = step.ToString();
                        queue.Enqueue(this.Labyrinth[current.X, right]);
                    }
                }

                if (below < this.Labyrinth.GetLength(0))
                {
                    if (this.Labyrinth[below, current.Y].Value == this.EMPTY)
                    {
                        this.Labyrinth[below, current.Y].Value = step.ToString();
                        queue.Enqueue(this.Labyrinth[below, current.Y]);
                    }
                }

                this.Unreachable.Remove(current);
                queue.Dequeue();
            }

            this.MarkUnreachable();
        }

        private void MarkUnreachable()
        {
            foreach (var item in this.Unreachable)
            {
                if (item.Value == this.EMPTY)
                {
                    this.Labyrinth[item.X, item.Y].Value = this.UNREACHABLE; 
                }
            }
        }
    }
}
