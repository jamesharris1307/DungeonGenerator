namespace DungeonGenerator;

public class Dungeon
{
    private readonly char[,] _map;
    private readonly List<Room> rooms = new();
    private readonly Random _random = new();

    // Create the dungeon by assigning '.' to all the inner cells and '#' to all the outer cells
    public Dungeon(int width, int height)
    {
        _map = new char[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (y == 0 || y == height - 1 ||
                    x == 0 || x == width - 1)
                {
                    _map[y, x] = '#';
                }
                else
                {
                    _map[y, x] = ' ';
                }
            }
        }
    }

    public bool PlaceRandomRoom(int width, int height)
    {
        int dungeonWidth = _map.GetLength(1);
        int dungeonHeight = _map.GetLength(0);
        
        // Check whether the room fits inside the dungeon
        if (width <= 0 || height <= 0 ||
            width > dungeonWidth - 2 ||
            height > dungeonHeight - 2)
        {
            return false;
        }
        
        // Attempt to find a suitable position
        for (int attempt = 0; attempt < 100; attempt++)
        {
            int x = _random.Next(1, dungeonWidth - width);
            int y = _random.Next(1, dungeonHeight - height);

            Room newRoom = new Room(x, y, width, height);

            if (!Overlaps(newRoom))
            {
                newRoom.GenerateRoom(_map);
                rooms.Add(newRoom);

                return true;
            }
        }

        return false;
    }
    
    // Check whether a room overlaps another room
    private bool Overlaps(Room newRoom)
    {
        foreach (Room existingRoom in rooms)
        {
            bool overlaps =
                newRoom.X < existingRoom.X + existingRoom.Width &&
                newRoom.X + newRoom.Width > existingRoom.X &&
                newRoom.Y < existingRoom.Y + existingRoom.Height &&
                newRoom.Y + newRoom.Height > existingRoom.Y;

            if (overlaps)
            {
                return true;
            }
        }

        return false;
    }
    
    // Display the Dungeon by looping through the rows and columns and writing to the console
    public void Display()
    {
        for (int y = 0; y < _map.GetLength(0); y++)
        {
            for (int x = 0; x < _map.GetLength(1); x++)
            {
                Console.Write(_map[y, x]);
            }

            Console.WriteLine();
        }
    }
}