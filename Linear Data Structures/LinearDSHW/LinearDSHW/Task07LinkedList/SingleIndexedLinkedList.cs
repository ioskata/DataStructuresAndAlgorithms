namespace Task07LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SingleIndexedLinkedList<T> : IEnumerable<T>
    {
        private class ListNode<T>
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public ListNode<T> NextNode { get; set; }
        }

        private ListNode<T> head;
        private ListNode<T> tail;

        public long Count { get; set; }

        private ListNode<T> this[long index]
        {
            get
            {
                if (index < 0 || index > this.Count - 1)
                {
                    throw new ArgumentOutOfRangeException("Index", index, "Index cannot be negative or bigger than the count of elements - 1.");
                }

                long i = 0;
                ListNode<T> currentNode = this.head;
                while (i != index)
                {
                    currentNode = currentNode.NextNode;
                    i++;
                }

                return currentNode;
            }
        }

        public void Add(T item)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(item);
            }
            else
            {
                ListNode<T> newTail = new ListNode<T>(item);
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public void Remove(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Can not remove item from empty collection.");
            }

            ListNode<T> removed = this[index];
            ListNode<T> previous = null;
            if (removed != this.head)
            {
                previous = this[index - 1];
                previous.NextNode = removed.NextNode;
            }
            else
            {
                this.head = this.head.NextNode;
            }

            this.Count--;
        }

        public long FirstIndexOf(T item)
        {
            long index = 0;
            foreach (T currentItem in this)
            {
                if (item.Equals(currentItem))
                {
                    break;
                }

                index++;
            }

            if (index > this.Count - 1)
            {
                return -1;
            }

            return index;
        }

        public long LastIndexOf(T item)
        {
            long lastIndex = -1;
            long index = 0;
            foreach (T currentItem in this)
            {
                if (item.Equals(currentItem))
                {
                    lastIndex = index;
                }

                index++;
            }

            return lastIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
