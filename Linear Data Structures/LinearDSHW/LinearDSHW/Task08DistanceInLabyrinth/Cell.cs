namespace Task08DistanceInLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public struct Cell : IEquatable<Cell>
    {
        public int X { get; set; }

        public int Y { get; set; }

        public string Value { get; set; }

        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }

        public bool Equals(Cell other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
    }
}
