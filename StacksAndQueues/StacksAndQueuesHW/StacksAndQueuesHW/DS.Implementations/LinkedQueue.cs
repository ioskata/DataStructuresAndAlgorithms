namespace DS.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LinkedQueue<T>
    {
        private QueueNode<T> tail;
        private QueueNode<T> head;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            var newNode = new QueueNode<T>(element);
            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else if (this.Count == 1)
            {
                this.head.NextNode = newNode;
                newNode.PrevNode = this.head;
                newNode.NextNode = null;
                this.tail = newNode;
            }
            else
            {
                newNode.PrevNode = this.tail;
                this.tail.NextNode = newNode;
                newNode.NextNode = null;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            T result;
            if (this.Count < 1)
            {
                throw new InvalidOperationException("The Queue is empty.");
            }

            result = this.head.Value;
            this.head = this.head.NextNode;
            if (null != this.head)
            {
                this.head.PrevNode = null;
            }

            this.Count--;

            return result;
        }

        public T Peek()
        {
            T result;
            if (this.Count < 1)
            {
                throw new InvalidOperationException("The Queue is empty.");
            }

            result = this.head.Value;
            return result;
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.Count];
            if (this.Count > 0)
            {
                int position = 0;
                var current = this.head;
                while (null != current)
                {
                    resultArr[position] = current.Value;
                    current = current.NextNode;
                    position++;
                }
            }

            return resultArr;
        }
    }
}
