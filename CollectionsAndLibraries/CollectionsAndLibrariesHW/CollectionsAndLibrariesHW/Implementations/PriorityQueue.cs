namespace Implementations
{
    using System;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private BinaryHeap<T> heap;

        public PriorityQueue(int capacity = 4)
        {
            this.heap = new BinaryHeap<T>(capacity);
        }
        public int Count
        {
            get { return this.heap.Count; }
        }

        public void Enqueue(T newElement)
        {
            this.heap.Insert(newElement);
        }

        public T Dequeue()
        {
            return this.heap.Pop();
        }

        public T Peek()
        {
            return this.heap.Peek();
        }

    }
}
