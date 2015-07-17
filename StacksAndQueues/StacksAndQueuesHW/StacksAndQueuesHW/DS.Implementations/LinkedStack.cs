namespace DS.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LinkedStack<T>
    {
        private StackNode<T> head;

        public int Count { get; private set; }

        public void Push(T element)
        {
            this.head = new StackNode<T>(element, this.head);
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Popping element from empty stack is not allowed.");
            }

            T result = this.head.Value;
            this.head = this.head.NextNode;
            this.Count--;
            return result;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Peeking element from empty stack is not allowed.");
            }

            T result = this.head.Value;
            return result;
        }

        public T[] ToArray()
        {
            T[] resultArr = new T[this.Count];
            int position = 0;
            var current = this.head;
            while (null != current)
            {
                resultArr[position] = current.Value;
                position++;
                current = current.NextNode;
            }

            return resultArr;
        }
    }
}
