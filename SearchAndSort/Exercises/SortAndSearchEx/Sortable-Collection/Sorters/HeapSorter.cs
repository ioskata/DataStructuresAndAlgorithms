namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            BinaryHeap<T> heap = new BinaryHeap<T>();
            foreach (var item in collection)
            {
                heap.Insert(item);
            }

            int count = collection.Count;
            collection.Clear();
            for (int i = 0; i < count; i++)
            {
                collection.Add( heap.ExtractMin());
            }
        }
    }
}
