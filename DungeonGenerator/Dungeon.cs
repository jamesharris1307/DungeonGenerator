namespace DungeonGenerator;

public class Dungeon
{
    private readonly CellType[,] _map;
    private readonly List<Room> _rooms = new();
    private readonly Random _random = new();

    // Create the dungeon by assigning cell types to the grid.
    public Dungeon(int width, int height)
    {
        _map = new CellType[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (y == 0 || y == height - 1 ||
                    x == 0 || x == width - 1)
                {
                    _map[y, x] = CellType.Boundary;
                }
                else
                {
                    _map[y, x] = CellType.Empty;
                }
            }
        }
    }

    public bool PlaceRandomRoom(int width, int height)
    {
        int dungeonWidth = _map.GetLength(1);
        int dungeonHeight = _map.GetLength(0);

        // Check the room fits inside the dungeon.
        if (width <= 0 || height <= 0 ||
            width > dungeonWidth - 2 ||
            height > dungeonHeight - 2)
        {
            return false;
        }

        // Attempt to find a suitable position.
        for (int attempt = 0; attempt < 100; attempt++)
        {
            int x = _random.Next(1, dungeonWidth - width);
            int y = _random.Next(1, dungeonHeight - height);

            Room newRoom = new Room(x, y, width, height);

            if (!Overlaps(newRoom))
            {
                newRoom.GenerateRoom(_map);
                
                // After room generated add to rooms list
                _rooms.Add(newRoom);
                return true;
            }
        }
        return false;
    }

    // Check if a room overlaps another room.
    private bool Overlaps(Room newRoom)
    {
        foreach (Room existingRoom in _rooms)
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

    // Connect rooms together using an L-shaped corridor.
    public void ConnectRooms()
    {
        for (int i = 0; i < _rooms.Count - 1; i++)
        {
            Room firstRoom = _rooms[i];
            Room secondRoom = _rooms[i + 1];

            int startX = firstRoom.CentreX;
            int startY = firstRoom.CentreY;

            int endX = secondRoom.CentreX;
            int endY = secondRoom.CentreY;

            // Horizontal corridor.
            int minX = Math.Min(startX, endX);
            int maxX = Math.Max(startX, endX);

            for (int x = minX; x <= maxX; x++)
            {
                // Place the corridor floor through the centre.
                CarveCorridorFloor(startY, x);

                // Place corridor walls above and below.
                PlaceCorridorWall(startY - 1, x);
                PlaceCorridorWall(startY + 1, x);
            }

            // Vertical corridor.
            int minY = Math.Min(startY, endY);
            int maxY = Math.Max(startY, endY);

            for (int y = minY; y <= maxY; y++)
            {
                // Place the corridor floor through the centre.
                CarveCorridorFloor(y, endX);

                // Place corridor walls to the left and right.
                PlaceCorridorWall(y, endX - 1);
                PlaceCorridorWall(y, endX + 1);
            }
        }
    }

    // Create a corridor floor without overwriting room floors or dungeon boundaries.
    private void CarveCorridorFloor(int y, int x)
    {
        if (_map[y, x] == CellType.Empty ||
            _map[y, x] == CellType.RoomWall ||
            _map[y, x] == CellType.CorridorWall)
        {
            _map[y, x] = CellType.CorridorFloor;
        }
    }

    // Only place corridor walls in empty cells.
    private void PlaceCorridorWall(int y, int x)
    {
        if (_map[y, x] == CellType.Empty)
        {
            _map[y, x] = CellType.CorridorWall;
        }
    }

    // Convert cell types into their corresponding ASCII characters.
    private char GetDisplayCharacter(CellType cell)
    {
        return cell switch
        {
            CellType.Empty => ' ',
            CellType.Boundary => '#',
            CellType.RoomWall => '#',
            CellType.RoomFloor => '.',
            CellType.CorridorWall => '#',
            CellType.CorridorFloor => '.',
            _ => '?'
        };
    }

    // Display the dungeon.
    public void Display()
    {
        for (int y = 0; y < _map.GetLength(0); y++)
        {
            for (int x = 0; x < _map.GetLength(1); x++)
            {
                Console.Write(GetDisplayCharacter(_map[y, x]));
            }
            Console.WriteLine();
        }
    }
}
