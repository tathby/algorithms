using System;
using System.Collections.Generic;

namespace Implements
{
    // Max-priority queue implemented as a binary heap stored in an array (List<T> backing)
    // Generic over T where T : IComparable<T>
    public class MaxPQArray<T> where T : IComparable<T>
    {
        private List<T> heap;

        public MaxPQArray()
        {
            heap = new List<T>();
        }

        public int Count => heap.Count;

        public bool IsEmpty => heap.Count == 0;

        public void Clear() => heap.Clear();

        public void Insert(T item)
        {
            heap.Add(item);
            SiftUp(heap.Count - 1);
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Priority queue is empty");
            return heap[0];
        }

        public T ExtractMax()
        {
            if (IsEmpty) throw new InvalidOperationException("Priority queue is empty");
            T max = heap[0];
            int last = heap.Count - 1;
            heap[0] = heap[last];
            heap.RemoveAt(last);
            if (!IsEmpty) SiftDown(0);
            return max;
        }

        public T[] ToArray() => heap.ToArray();

        private void SiftUp(int idx)
        {
            while (idx > 0)
            {
                int parent = (idx - 1) / 2;
                if (heap[idx].CompareTo(heap[parent]) <= 0) break;
                Swap(idx, parent);
                idx = parent;
            }
        }

        private void SiftDown(int idx)
        {
            int n = heap.Count;
            while (true)
            {
                int left = 2 * idx + 1;
                int right = 2 * idx + 2;
                int largest = idx;
                if (left < n && heap[left].CompareTo(heap[largest]) > 0) largest = left;
                if (right < n && heap[right].CompareTo(heap[largest]) > 0) largest = right;
                if (largest == idx) break;
                Swap(idx, largest);
                idx = largest;
            }
        }

        private void Swap(int i, int j)
        {
            T tmp = heap[i];
            heap[i] = heap[j];
            heap[j] = tmp;
        }
    }
}
