
namespace DungeonGenerator;

internal static class Program
{
    private static bool _running = true;
    private static Dungeon? _dungeon;

    private static void Main()
    {
        while (_running)
        {
            DisplayMenu();
            ProcessMenuChoice();
        }
    }
    
    private static void DisplayMenu()
    {
        Console.WriteLine("========== Dungeon Generator ==========");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("1. Create a Dungeon");
        Console.WriteLine("2. Place a Room");
        Console.WriteLine("3. Generate Procedural Dungeon");
        Console.WriteLine("4. Clear Console");
        Console.WriteLine("5. Quit the program");
    }

    private static void ProcessMenuChoice()
    {
        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Please enter a valid number.");
            return;
        }

        switch (choice)
        {
            case 1:
                CreateDungeon();
                break;

            case 2:
                PlaceRoom();
                break;

            case 3:
                GenerateProceduralDungeon();
                break;

            // Going to allow the user to configure the symbols representing the map
            // boundaries, empty cells and walls.

            case 4:
                ClearConsole();
                break;
            
            // Exit Game.
            case 5:
                QuitProgram();
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    // Create a dungeon following user parameters.
    private static void CreateDungeon()
    {
        Console.Write("Enter dungeon width: ");

        if (!int.TryParse(Console.ReadLine(), out int width))
        {
            Console.WriteLine("Invalid width.");
            return;
        }

        Console.Write("Enter dungeon height: ");

        if (!int.TryParse(Console.ReadLine(), out int height))
        {
            Console.WriteLine("Invalid height.");
            return;
        }

        _dungeon = new Dungeon(width, height);
        _dungeon.Display();
    }

    // Create and Place a Room.
    private static void PlaceRoom()
    {
        if (_dungeon is null)
        {
            Console.WriteLine("Create a dungeon first.");
            return;
        }

        Console.Write("Enter room width: ");

        if (!int.TryParse(Console.ReadLine(), out int roomWidth))
        {
            Console.WriteLine("Invalid room width.");
            return;
        }

        Console.Write("Enter room height: ");

        if (!int.TryParse(Console.ReadLine(), out int roomHeight))
        {
            Console.WriteLine("Invalid room height.");
            return;
        }

        bool placed = _dungeon.PlaceRandomRoom(roomWidth, roomHeight);

        if (placed)
        {
            Console.WriteLine("\nRoom successfully placed!");
        }
        else
        {
            Console.WriteLine("\nCould not find a suitable position.");
        }

        _dungeon.ConnectRooms();
        _dungeon.Display();
    }

    // Generate a procedural dungeon.
    private static void GenerateProceduralDungeon()
    {
        Console.Write("Enter dungeon width: ");

        if (!int.TryParse(Console.ReadLine(), out int width))
        {
            Console.WriteLine("Invalid width.");
            return;
        }

        Console.Write("Enter dungeon height: ");

        if (!int.TryParse(Console.ReadLine(), out int height))
        {
            Console.WriteLine("Invalid height.");
            return;
        }

        Console.Write("Enter number of rooms: ");

        if (!int.TryParse(Console.ReadLine(), out int roomCount))
        {
            Console.WriteLine("Invalid room count.");
            return;
        }

        ProceduralDungeonGenerator generator = new ProceduralDungeonGenerator();

        _dungeon = generator.Generate(width, height, roomCount);

        _dungeon.Display();
    }

    private static void ClearConsole()
    {
        Console.Clear();
    }
    
    // Exit Game.
    private static void QuitProgram()
    {
        Console.WriteLine("Exiting...");
        _running = false;
    }
}
