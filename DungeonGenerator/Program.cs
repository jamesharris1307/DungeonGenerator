namespace DungeonGenerator;

internal static class Program
{
    private static void Main()
    {
        const bool running = true;
        Dungeon? dungeon = null;

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

                    dungeon = new Dungeon(width, height);

                    dungeon.Display();
                    break;
            
                // Create and Place a Room
                case 2:
                    if (dungeon is null)
                    {
                        Console.WriteLine("Create a dungeon first.");
                        break;
                    }
                    
                    Console.Write("Enter room width: ");
                    int roomWidth = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter room height: ");
                    int roomHeight = Convert.ToInt32(Console.ReadLine());
                    
                    bool placed = dungeon.PlaceRandomRoom(roomWidth, roomHeight);

                    if (placed)
                    {
                        Console.WriteLine("\nRoom successfully placed!");
                    }
                    else
                    {
                        Console.WriteLine("\nCould not find a suitable position.");
                    }

                    dungeon.Display();
                    break;
            
                case 3:
                    // Going to allow the user to congigure the symbols representing the map
                    // boundaries, empty cells and walls
                
                // Exit Game
                case 4:
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
