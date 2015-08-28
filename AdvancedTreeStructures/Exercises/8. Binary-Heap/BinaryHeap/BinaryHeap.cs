﻿using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public BinaryHeap(T[] elements)
    {
        this.heap = new List<T>(elements);
        for (int i = this.heap.Count / 2; i >= 0; i--)
        {
            this.HeapifyDown(i);
        }
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public T ExtractMax()
    {
        var max = this.heap[0];
        this.heap[0] = this.heap[this.Count - 1];
        this.heap.RemoveAt(this.Count - 1);
        if (this.Count > 0)
        {
            this.HeapifyDown(0);
        }

        return max;
    }

    public T PeekMax()
    {
        return this.heap[0];
    }

    public void Insert(T node)
    {
        this.heap.Add(node);
        HeapifyUp(this.heap.Count - 1);
    }

    private void HeapifyDown(int i)
    {
        var left = 2 * i + 1;
        var right = 2 * i + 2;
        var largest = i;

        if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[largest]) > 0)
        {
            largest = left;
        }

        if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[largest]) > 0)
        {
            largest = right;
        }

        if (largest != i)
        {
            Swap(i, largest);
            HeapifyDown(largest);
        }
    }

    private void Swap(int first, int second)
    {
        T temp = this.heap[first];
        this.heap[first] = this.heap[second];
        this.heap[second] = temp;
    }

    private void HeapifyUp(int i)
    {
        var parent = (i - 1) / 2;
        while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) > 0)
        {
            this.Swap(i, parent);
            i = parent;
            parent = (i - 1) / 2;
        }
    }
}
