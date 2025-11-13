using System;
using System.Collections.Generic;

namespace Implements
{
    // Max-priority queue implemented as a binary heap using linked tree nodes.
    // Internally we keep track of Count and use binary representation of insertion index
    // to navigate to the insertion/removal position.
    public class MaxPQTree<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Value;
            public Node Left;
            public Node Right;
            public Node Parent;

            public Node(T value)
            {
                Value = value;
            }
        }

        private Node root;
        private int count;

        public MaxPQTree()
        {
            root = null;
            count = 0;
        }

        public int Count => count;
        public bool IsEmpty => count == 0;

        public void Clear()
        {
            root = null;
            count = 0;
        }

        public void Insert(T item)
        {
            Node node = new Node(item);
            count++;
            if (root == null)
            {
                root = node;
                return;
            }

            // find parent for new node using binary representation of count
            Node parent = NavigateToParentForIndex(count);
            node.Parent = parent;
            if (parent.Left == null) parent.Left = node;
            else parent.Right = node;

            SiftUp(node);
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Priority queue is empty");
            return root.Value;
        }

        public T ExtractMax()
        {
            if (IsEmpty) throw new InvalidOperationException("Priority queue is empty");
            T max = root.Value;
            if (count == 1)
            {
                root = null;
                count = 0;
                return max;
            }

            // find last node
            Node last = NavigateToNodeByIndex(count);
            root.Value = last.Value;
            if (last.Parent.Left == last) last.Parent.Left = null; else last.Parent.Right = null;
            count--;

            SiftDown(root);
            return max;
        }

        private Node NavigateToParentForIndex(int index)
        {
            string bits = Convert.ToString(index, 2);
            string parentBits = bits.Substring(0, bits.Length - 1);
            return NavigateByBits(parentBits);
        }

        private Node NavigateToNodeByIndex(int index)
        {
            string bits = Convert.ToString(index, 2);
            return NavigateByBits(bits);
        }

        private Node NavigateByBits(string bits)
        {
            if (string.IsNullOrEmpty(bits)) return null;
            Node current = root;
            for (int i = 1; i < bits.Length; i++)
            {
                if (current == null) break;
                if (bits[i] == '0') current = current.Left;
                else current = current.Right;
            }
            return current;
        }

        private void SiftUp(Node node)
        {
            while (node.Parent != null && node.Value.CompareTo(node.Parent.Value) > 0)
            {
                T tmp = node.Parent.Value;
                node.Parent.Value = node.Value;
                node.Value = tmp;
                node = node.Parent;
            }
        }

        private void SiftDown(Node node)
        {
            while (node != null)
            {
                Node largest = node;
                if (node.Left != null && node.Left.Value.CompareTo(largest.Value) > 0) largest = node.Left;
                if (node.Right != null && node.Right.Value.CompareTo(largest.Value) > 0) largest = node.Right;
                if (largest == node) break;
                T tmp = node.Value;
                node.Value = largest.Value;
                largest.Value = tmp;
                node = largest;
            }
        }

        public T[] ToArray()
        {
            if (root == null) return Array.Empty<T>();
            T[] res = new T[count];
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            int i = 0;
            while (q.Count > 0 && i < res.Length)
            {
                Node n = q.Dequeue();
                res[i++] = n.Value;
                if (n.Left != null) q.Enqueue(n.Left);
                if (n.Right != null) q.Enqueue(n.Right);
            }
            return res;
        }
    }
}
