namespace DungeonGenerator;

// This class stores a rooms position and dimenstions.
// It calculates the rooms centre point and contains logic for
// placing the floors and walls 

public class Room(int x, int y, int width, int height)
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public int Width { get; } = width;
    public int Height { get; } = height;
    public int CentreX => X + Width / 2;
    public int CentreY => Y + Height / 2;

    // Y represents rows (Vertical Movement)
    // X represents columns (Horizontal Movement)
    
    public void GenerateRoom(CellType[,] map)
    {
        // Loop through the rows
        for (int y = 0; y < Height; y++)
        {
            // Loop through the columns
            for (int x = 0; x < Width; x++)
            {
                // Detect a boundary cell
                if (y == 0 || y == Height - 1 ||
                    x == 0 || x == Width - 1)
                {
                    // Assign Room Wall Cell Type
                    map[Y + y, X + x] = CellType.RoomWall;
                }
                else
                {
                    // Assign Room Floor Cell Type
                    map[Y + y, X + x] = CellType.RoomFloor;
                }
            }
        }
    }
}