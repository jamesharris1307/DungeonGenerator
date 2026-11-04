using DungeonGenerator;

namespace DungeonGenerator;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("========== Dungeon Generator ==========");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("1. Create a Dungeon");
        Console.WriteLine("2. Place a Room");
        Console.WriteLine("3. Quit the program");

        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice != 1 && choice != 2 && choice != 3)
        {
            return;
        }

        if (choice == 1)
        {
            // Create Dungeon
        }

        if (choice == 2)
        {
            // If Dungeon exists add room
        }

        if (choice == 3)
        {
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }
    }
}
