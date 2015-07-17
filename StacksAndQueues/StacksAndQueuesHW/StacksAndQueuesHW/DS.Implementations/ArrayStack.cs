namespace DS.Implementations
{
    using System;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] elements;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return this.elements[this.Count - 1];
        }

        public void Push(T element)
        {
            if (this.elements.Length == this.Count)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T result = this.elements[this.Count - 1];
            this.Count--;
            return result;
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.Count];

            for (int i = this.Count - 1; i >= 0; i--)
            {
                resultArr[this.Count - 1 - i] = this.elements[i];
            }

            return resultArr;
        }

        private void Grow()
        {
            var newElements = new T[2 * this.elements.Length];
            Array.Copy(this.elements, newElements, this.Count);
            this.elements = newElements;
        }
    }
}
