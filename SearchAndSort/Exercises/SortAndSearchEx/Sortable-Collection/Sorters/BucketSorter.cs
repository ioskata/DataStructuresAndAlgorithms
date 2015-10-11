namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class BucketSorter : ISorter<int>
    {
        public void Sort(List<int> collection)
        {
            int n = collection.Count;
            var buckets = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                int key = RangeDefinition(collection, i);
                if (buckets[key] == null)
                {
                    buckets[key] = new List<int>();
                }

                buckets[key].Add(collection[i]);
            }

            collection.Clear();
            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] != null)
                {
                    buckets[i].Sort();
                    collection.AddRange(buckets[i]);
                }
            }
        }

        private int RangeDefinition(List<int> collection, int index)
        {
            return (int)(collection[index] / this.Max * collection.Count);
        }

        public double Max { get; set; }
    }
}
