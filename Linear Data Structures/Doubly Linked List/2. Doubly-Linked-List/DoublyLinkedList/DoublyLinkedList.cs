using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public ListNode<T> NextNode { get; set; }

        public ListNode<T> PrevNode { get; set; }
    }

    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(element);
        }
        else
        {
            ListNode<T> newHead = new ListNode<T>(element);
            newHead.NextNode = this.head;
            this.head.PrevNode = newHead;
            this.head = newHead;
        }

        this.Count++;
    }

    public void AddLast(T element)
    {
        if (this.Count == 0)
        {
            this.AddFirst(element);
        }
        else
        {
            ListNode<T> newTail = new ListNode<T>(element);
            newTail.PrevNode = this.tail;
            this.tail.NextNode = newTail;
            this.tail = newTail;
            this.Count++;
        }

    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List empty.");
        }

        T removed;
        removed = this.head.Value;
        if (this.Count == 1)
        {
            this.head = this.tail = null;
        }
        else
        {
            this.head = this.head.NextNode;
            this.head.PrevNode = null;
        }

        this.Count--;
        return removed;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List empty.");
        }

        T removed;
        removed = this.tail.Value;

        if (this.Count == 1)
        {
            this.tail = this.head = null;
        }
        else
        {
            this.tail = this.tail.PrevNode;
            this.tail.NextNode = null;
        }

        this.Count--;
        return removed;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this.head;
        while (null != currentNode)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        ListNode<T> currentNode = this.head;
        while (null != currentNode)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] result = new T[this.Count];
        ListNode<T> currentNode = this.head;
        int i = 0;
        while (null != currentNode)
        {
            result[i] = currentNode.Value;
            currentNode = currentNode.NextNode;
            i++;
        }

        return result;
    }
}

class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
