namespace DungeonGenerator;

public class MainMenu
{
    private static Dungeon? _dungeon;
    private static DungeonRenderer _renderer = new DungeonRenderer();
    
    public static void DisplayMenu()
    {
        Console.WriteLine("========== Dungeon Generator ==========");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("1. Create a Dungeon");
        Console.WriteLine("2. Place a Room");
        Console.WriteLine("3. Generate Procedural Dungeon");
        Console.WriteLine("4. Clear Console");
        Console.WriteLine("5. Create Character");
        Console.WriteLine("6. Load Character");
        Console.WriteLine("7. Quit the program");
    }
        
    public static void ProcessMenuChoice()
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
            // boundaries, empty cells and walls

            case 4:
                ClearConsole();
                break;
            
            case 5:
                CreateCharacter();
                break;
            
            case 6:
                LoadCharacter();
                //KeyboardInput.ProcessInput();
                break;
            
            // Exit Game.
            case 7:
                QuitProgram();
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    // Create a dungeon following user parameters
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
        _renderer.Display(_dungeon);
    }

    // Create and Place a Room
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
        _renderer.Display(_dungeon);
    }

    // Generate a Character
    private static void CreateCharacter()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Invalid name.");
            return;
        }

        Character.CreateCharacter(name);
    }
    
    // Load a Character
    private static void LoadCharacter()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Invalid name.");
            return;
        }
        
        var player = new Player(0, 0);
        
        Console.WriteLine(player.XPos + " : " + player.YPos);
    }
    
    // Generate a procedural dungeon
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
        _renderer.Display(_dungeon);
    }

    private static void ClearConsole()
    {
        Console.Clear();
    }
    
    // Exit Game
    private static void QuitProgram()
    {
        Console.WriteLine("Exiting...");
        Environment.Exit(0);
    }
}