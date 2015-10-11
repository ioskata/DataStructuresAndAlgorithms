namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private Func<T, T, int> Subtract;
        private Func<T, T, int> Multiply;

        public SortableCollection()
        {
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(IEnumerable<T> items, Func<T, T, int> subtract, Func<T, T, int> multiply)
            : this(items)
        {
            this.Multiply = multiply;
            this.Subtract = subtract;
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; } = new List<T>();

        public int Count => this.Items.Count;

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            return this.BinarySearch(this.Items.ToArray(), item, 0, this.Items.Count - 1);
        }

        public int InterpolationSearch(T item)
        {
            return this.InterpolationSearch(this.Items.ToArray(), item);
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Items)}]";
        }

        private int BinarySearch(T[] array, T item, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }
            if (array.Length < 1)
            {
                return -1;
            }

            int mid = (start + end) / 2;
            if (array[mid].CompareTo(item) > 0)
            {
                return BinarySearch(array, item, start, mid - 1);
            }
            else if (array[mid].CompareTo(item) < 0)
            {
                return BinarySearch(array, item, mid + 1, end);
            }
            else
            {
                return mid;
            }
        }

        private int InterpolationSearch(T[] array, T item)
        {
            if (array.Length < 1)
            {
                return -1;
            }

            int low = 0;
            int high = array.Length - 1;
            int mid;
            while (array[high].CompareTo(array[low]) != 0 &&
                item.CompareTo(array[low]) >= 0 &&
                item.CompareTo(array[high]) <= 0)
            {
                mid = low + this.Subtract(item, array[low]) * (high - low) / this.Subtract(array[high], array[low]);

                if (array[mid].CompareTo(item) < 0)
                {
                    low = mid + 1;
                }
                else if (array[mid].CompareTo(item) > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (item.CompareTo(array[low]) == 0)
            {
                return low;
            }
            else
            {
                return -1;
            }
        }
    }
}