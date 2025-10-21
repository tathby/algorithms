using System;
using System.Collections.Generic;
using IteratorPattern;

public class StackIterator<T> : IIterator<T>
{
    private readonly Stack<T> stack;
    private int currentIndex;

    public StackIterator(Stack<T> stack)
    {
        this.stack = stack ?? throw new ArgumentNullException(nameof(stack));
        this.currentIndex = stack.Count - 1; // start from the top
    }

    public bool HasNext()
    {
        return currentIndex >= 0;
    }

    public T Next()
    {
        if (!HasNext())
            throw new InvalidOperationException("No more elements in the stack.");

        return stack[currentIndex--];
    }
}

public class Stack<T>
{
    private readonly List<T> elements = new List<T>();
    public int Count => elements.Count;
    public T this[int index] => elements[index];
    public void Push(T item)
    {
        elements.Add(item);
    }
    public T Pop()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        T item = elements[Count - 1];
        elements.RemoveAt(Count - 1);
        return item;
    }
    public bool IsEmpty()
    {
        return Count == 0;
    }
    public IIterator<T> CreateIterator()
    {
        return new StackIterator<T>(this);
    }
}
