namespace HanoiTowerr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Tower of Hanoi!");
            Console.Write("Enter number of disks: ");
            int numDisks = int.TryParse(Console.ReadLine(), out int n) ? n : 3;

            var tower = new TowerOfHanoi(numDisks);

            Console.Write("Choose mode: (1) Manual, (2) Auto-solve: ");
            string choice = Console.ReadLine() ?? "2";

            if (choice == "1")
                tower.PlayManual();
            else
                tower.AutoSolve();
        }
    }
}
