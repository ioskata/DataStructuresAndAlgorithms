using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalTree
{
    public struct Interval<T> where T : IComparable<T>
    {

        public Interval(T start, T end)
            : this()
        {
            if (start.CompareTo(end) >= 0)
            {
                throw new ArgumentException("the start value of the interval must be smaller than the end value. null interval are not allowed");
            }

            this.Start = start;
            this.End = end;
        }


        public T Start;
        public T End;

        /// <summary>
        /// Determines if two intervals overlap (i.e. if this interval starts before the other ends and it finishes after the other starts)
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        ///   <c>true</c> if the specified other is overlapping; otherwise, <c>false</c>.
        /// </returns>
        public bool OverlapsWith(Interval<T> other)
        {
            return (this.Start.CompareTo(other.End) < 0 && this.End.CompareTo(other.Start) > 0);
        }

        public override string ToString()
        {
            return "[" + Start.ToString() + "," + End.ToString() + "]";
        }
    }

}
