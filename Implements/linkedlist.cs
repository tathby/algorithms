// LinkedList Implementation in C#
namespace IteratorPattern;
public class LinkedListNode<T>
{
    public T Value;
    public LinkedListNode<T> Next;

    public LinkedListNode(T value)
    {
        Value = value;
        Next = null;
    }
}

public class LinkedList<T>
{
    // Nested iterator class implementing IIterator<T>
    private class LinkedListIterator : IIterator<T>
    {
        private LinkedListNode<T> current;

        public LinkedListIterator(LinkedList<T> list)
        {
            current = list.head;
        }

        public bool HasNext()
        {
            return current != null;
        }

        public T Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("No more elements in iterator.");

            T value = current.Value;
            current = current.Next;
            return value;
        }
    }
    public void Print()
    {
        var iterator = GetIterator();
        while (iterator.HasNext())
        {
            Console.Write(iterator.Next() + " ");
        }
        Console.WriteLine();
    }
    private LinkedListNode<T> head;

    public void AddLast(T value)
    {
        var newNode = new LinkedListNode<T>(value);
        if (head == null)
        {
            head = newNode;
            return;
        }

        var current = head;
        while (current.Next != null)
            current = current.Next;
        current.Next = newNode;
    }

    public void RemoveLast()
    {
        if (head == null) return;
        if (head.Next == null)
        {
            head = null;
            return;
        }

        var current = head;
        while (current.Next.Next != null)
            current = current.Next;
        current.Next = null;
    }

    public void AddFirst(T value)
    {
        var newNode = new LinkedListNode<T>(value);
        newNode.Next = head;
        head = newNode;
    }

    public void RemoveFirst()
    {
        if (head == null) return;
        head = head.Next;
    }

    public T GetFirst()
    {
        if (head == null) throw new InvalidOperationException("List is empty");
        return head.Value;
    }

    public T GetLast()
    {
        if (head == null) throw new InvalidOperationException("List is empty");
        var current = head;
        while (current.Next != null)
            current = current.Next;
        return current.Value;
    }

    public T Get(int index)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        var current = head;
        for (int i = 0; i < index; i++)
        {
            if (current == null) throw new ArgumentOutOfRangeException(nameof(index));
            current = current.Next;
        }
        return current.Value;
    }

    public T Set(int index, T value)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        var current = head;
        for (int i = 0; i < index; i++)
        {
            if (current == null) throw new ArgumentOutOfRangeException(nameof(index));
            current = current.Next;
        }
        current.Value = value;
        return current.Value;
    }

    public IIterator<T> GetIterator()
    {
        return new LinkedListIterator(this);
    }
}

// Example usage
//class Program
//{
//    static void Main()
//    {
//        var list = new LinkedList<int>();
//        list.AddLast(1);
//        list.AddLast(2);
//        list.AddLast(3);

//        Console.WriteLine("Printing list with iterator:");
//        list.Print(); // Output: 1 2 3

//        Console.WriteLine("Manual iteration:");
//        var it = list.GetIterator();
//        while (it.HasNext())
//        {
//            Console.WriteLine(it.Next());
//        }
//    }
//}
