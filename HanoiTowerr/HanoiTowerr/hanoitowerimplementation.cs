public class TowerOfHanoi
{
    private readonly IteratorPattern.Stack<int>[] towers;
    private readonly int numDisks;

    public TowerOfHanoi(int numDisks)
    {
        this.numDisks = numDisks;
        towers = new IteratorPattern.Stack<int>[3];
        for (int i = 0; i < 3; i++)
            towers[i] = new IteratorPattern.Stack<int>();

        for (int i = numDisks; i >= 1; i--)
            towers[0].Push(i);
    }

    public void PlayManual()
    {
        Console.WriteLine("\n--- Tower of Hanoi ---");
        Console.WriteLine("Move all disks from Tower 1 to Tower 3.");
        Console.WriteLine("You can only move smaller disks onto larger ones.");

        while (towers[2].Count != numDisks)
        {
            PrintTowers();

            Console.Write("\nPick a tower to move FROM (1–3): ");
            if (!int.TryParse(Console.ReadLine(), out int from) || from < 1 || from > 3)
            {
                Console.WriteLine("Invalid tower. Try again.");
                continue;
            }

            Console.Write($"Pick a tower to move TO (1–3): ");
            if (!int.TryParse(Console.ReadLine(), out int to) || to < 1 || to > 3)
            {
                Console.WriteLine("Invalid tower. Try again.");
                continue;
            }

            if (from == to)
            {
                Console.WriteLine("Cannot move onto the same tower.");
                continue;
            }

            if (!IsValidMove(from - 1, to - 1))
            {
                Console.WriteLine("Invalid move (can’t place larger on smaller). Try again.");
                continue;
            }

            MoveDisk(from - 1, to - 1);
        }

        PrintTowers();
        Console.WriteLine("\n🎉 Congratulations! You solved the Tower of Hanoi!");
    }

    private bool IsValidMove(int from, int to)
    {
        if (towers[from].Count == 0)
            return false;

        if (towers[to].Count == 0)
            return true;

        int fromTop = towers[from][towers[from].Count - 1];
        int toTop = towers[to][towers[to].Count - 1];
        return fromTop < toTop;
    }

    private void MoveDisk(int from, int to)
    {
        int disk = towers[from].Pop();
        towers[to].Push(disk);
    }

    private void PrintTowers()
    {
        Console.WriteLine("\nCurrent Towers:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Tower {i + 1}: ");
            for (int j = 0; j < towers[i].Count; j++)
            {
                Console.Write(towers[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void AutoSolve()
    {
        Console.WriteLine($"\nAuto-solving Tower of Hanoi for {numDisks} disks...\n");

        IteratorPattern.Queue<(int from, int to)> moves = new IteratorPattern.Queue<(int from, int to)>();
        GenerateMoves(numDisks, 0, 2, 1, moves);

        while (moves.GetIterator().HasNext())
        {
            var move = moves.Dequeue();
            MoveDisk(move.from, move.to);
            PrintTowers();
            Thread.Sleep(500);
        }

        Console.WriteLine("\n✅ Auto-solve complete!");
    }

    private void GenerateMoves(int n, int from, int to, int aux, IteratorPattern.Queue<(int, int)> queue)
    {
        if (n == 1)
        {
            queue.Enqueue((from, to));
            return;
        }

        GenerateMoves(n - 1, from, aux, to, queue);
        queue.Enqueue((from, to));
        GenerateMoves(n - 1, aux, to, from, queue);
    }
}
