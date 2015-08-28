namespace AATree
{
    using System;

    public class Node<TValue> where TValue : IComparable<TValue>
    {
        internal int level;
        internal Node<TValue> left;
        internal Node<TValue> right;

        public Node()
        {
            this.left = this;
            this.right = this;
        }

        public Node(TValue value, Node<TValue> sentinel)
        {
            this.level = 1;
            this.left = sentinel;
            this.right = sentinel;
            this.Value = value;
        }
        public TValue Value { get; set; }
    }
}
