namespace Task08DistanceInLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ILabyrinth
    {
        Cell StartCell { get; set; }

        void Print();

        void CalculateDistances();
    }
}
