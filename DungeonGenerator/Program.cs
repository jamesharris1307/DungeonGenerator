using DungeonGenerator;

namespace DungeonGenerator;

internal static class Program
{
    private static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("========== Dungeon Generator ==========");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Create a Dungeon");
            Console.WriteLine("2. Place a Room");
            Console.WriteLine("3. Quit the program");

            int choice = Convert.ToInt32(Console.ReadLine());
        
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Creating a Dungeon");
                    break;
            
                case 2:
                    Console.WriteLine("Placing a Room");
                    break;
            
                case 3:
                    Console.WriteLine("Exiting . . .");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
