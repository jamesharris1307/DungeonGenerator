namespace DungeonGenerator;

internal static class Program
{
    private static void Main()
    {
        const bool running = true;

        while (running)
        {
            Console.WriteLine("========== Dungeon Generator ==========");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Create a Dungeon");
            Console.WriteLine("2. Place a Room");
            Console.WriteLine("3. Quit the program");

            var choice = Convert.ToInt32(Console.ReadLine());
        
            switch (choice)
            {
                // Create a Dungeon following user parameters
                case 1:
                    Console.Write("Enter dungeon width: ");
                    int width = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter dungeon height: ");
                    int height = Convert.ToInt32(Console.ReadLine());

                    Dungeon dungeon = new Dungeon(width, height);

                    dungeon.Display();
                    break;
            
                // Create and Place a Room
                case 2:
                    Console.WriteLine("Placing a Room");
                    break;
            
                // Exit Game
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
