namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                int targetIndex = i;
                for (int j = i; j >= 0; j--)
                {
                    if (collection[targetIndex].CompareTo(collection[j]) < 0)
                    {
                        Swap(collection, targetIndex, j);
                        targetIndex--;
                    }
                }
            }
        }

        private void Swap(List<T> collection, int first, int second)
        {
            T temp = collection[first];
            collection[first] = collection[second];
            collection[second] = temp;
        }
    }
}
