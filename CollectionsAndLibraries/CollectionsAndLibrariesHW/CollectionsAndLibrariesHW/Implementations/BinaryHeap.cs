namespace Implementations
{
    using System;
    using System.Collections.Generic;

    public class BinaryHeap<T> where T : IComparable<T>
    {
        protected T[] data;
        protected int count = 0;
        protected Comparison<T> comparison;

        public BinaryHeap()
            : this(4, null)
        {
        }

        public BinaryHeap(Comparison<T> comparison)
            : this(4, comparison)
        {
        }

        public BinaryHeap(int capacity)
            : this(capacity, null)
        {
        }

        public BinaryHeap(int capacity, Comparison<T> comparison)
        {
            this.data = new T[capacity];
            this.comparison = comparison;
            if (this.comparison == null)
                this.comparison = new Comparison<T>(Comparer<T>.Default.Compare);
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Insert(T item)
        {
            if (this.count == data.Length)
                Resize();
            this.data[this.count] = item;
            HeapifyUp(this.count);
            this.count++;
        }

        /// <summary>
        /// Get the item of the root
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return this.data[0];
        }

        /// <summary>
        /// Extract the item of the root
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T item = this.data[0];
            this.count--;
            this.data[0] = this.data[this.count];
            HeapifyDown(0);
            return item;
        }

        private void Resize()
        {
            T[] resizedData = new T[this.data.Length * 2];
            Array.Copy(this.data, 0, resizedData, 0, this.data.Length);
            this.data = resizedData;
        }

        private void HeapifyUp(int childIndex)
        {
            if (childIndex > 0)
            {
                int parentIdx = (childIndex - 1) / 2;
                if (comparison.Invoke(data[childIndex], data[parentIdx]) > 0)
                {
                    T t = data[parentIdx];
                    data[parentIdx] = data[childIndex];
                    data[childIndex] = t;
                    HeapifyUp(parentIdx);
                }
            }
        }

        private void HeapifyDown(int parentIndex)
        {
            int leftChildIndex = 2 * parentIndex + 1;
            int rightChildIndex = leftChildIndex + 1;
            int largestChildIndex = parentIndex;
            if (leftChildIndex < this.count && comparison.Invoke(this.data[leftChildIndex], this.data[largestChildIndex]) > 0)
            {
                largestChildIndex = leftChildIndex;
            }
            if (rightChildIndex < this.count && comparison.Invoke(this.data[rightChildIndex], this.data[largestChildIndex]) > 0)
            {
                largestChildIndex = rightChildIndex;
            }
            if (largestChildIndex != parentIndex)
            {
                T t = this.data[parentIndex];
                this.data[parentIndex] = this.data[largestChildIndex];
                this.data[largestChildIndex] = t;
                HeapifyDown(largestChildIndex);
            }
        }
    }
}
