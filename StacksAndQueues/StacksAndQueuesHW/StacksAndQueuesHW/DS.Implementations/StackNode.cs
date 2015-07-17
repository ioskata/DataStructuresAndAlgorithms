namespace DS.Implementations
{
    public class StackNode<T>
    {
        private T value;

        public StackNode(T value, StackNode<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public StackNode<T> NextNode { get; set; }
    }
}
