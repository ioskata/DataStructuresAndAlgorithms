namespace ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class ConnectedArea : IComparable<ConnectedArea>
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public int Size { get; set; }

        public int CompareTo(ConnectedArea other)
        {
            int compareSize = -1 * this.Size.CompareTo(other.Size);
            if (compareSize == 0)
            {
                int compareRows = this.Row.CompareTo(other.Row);
                if (compareRows == 0)
                {
                    return this.Column.CompareTo(other.Column);
                }
                else
                {
                    return compareRows;
                }
            }
            else
            {
                return compareSize;
            }
        }
    }
}
