// Queue Implementation
namespace AlgoPortfolio.Implements;

public class QueueIterator<T> : IIterator<T>
{
    private LinkedListNode<T> current;

    public QueueIterator(LinkedListNode<T> head)
    {
        current = head;
    }

    public bool HasNext()
    {
        return current != null;
    }

    public T Next()
    {
        if (!HasNext())
        {
            throw new InvalidOperationException("No more elements in the iterator.");
        }

        T value = current.Value;
        current = current.Next;
        return value;
    }
}

public class Queue<T>
{
    private LinkedListNode<T> head;
    private LinkedListNode<T> tail;


    public Queue()
    {
        head = null;
        tail = null;
    }

    public void Enqueue(T item)
    {
        var newNode = new LinkedListNode<T>(item);
        if (tail != null)
        {
            tail.Next = newNode;
        }
        tail = newNode;
        if (head == null)
        {
            head = newNode;
        }
    }

    public T Dequeue()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        T value = head.Value;
        head = head.Next;
        if (head == null)
        {
            tail = null;
        }
        return value;
    }

    public IIterator<T> GetIterator()
    {
        return new QueueIterator<T>(head);
    }

    public int Count
    {
        get
        {
            int count = 0;
            var current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}