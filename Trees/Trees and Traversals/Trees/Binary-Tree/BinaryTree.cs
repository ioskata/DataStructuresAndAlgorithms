using System;

public class BinaryTree<T>
{
    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
        this.Value = value;
        this.LeftChild = leftChild;
        this.RightChild = rightChild;
    }

    public T Value { get; set; }

    public BinaryTree<T> LeftChild { get; set; }

    public BinaryTree<T> RightChild { get; set; }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        Console.WriteLine("{0}{1}", new string(' ', 2 * indent), this.Value);

        if (null != this.LeftChild)
        {
            this.LeftChild.PrintIndentedPreOrder(indent + 1);
        }

        if (null != this.RightChild)
        {
            this.RightChild.PrintIndentedPreOrder(indent + 1);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        if (null != this.LeftChild)
        {
            this.LeftChild.EachInOrder(action);
        }

        action(this.Value);

        if (null != this.RightChild)
        {
            this.RightChild.EachInOrder(action);
        }
    }

    public void EachPostOrder(Action<T> action)
    {
        if (null != this.LeftChild)
        {
            this.LeftChild.EachPostOrder(action);
        }

        if (null != this.RightChild)
        {
            this.RightChild.EachPostOrder(action);
        }

        action(this.Value);
    }
}
