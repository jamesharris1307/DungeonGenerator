namespace DungeonGenerator;

public class Room(int x, int y, int width, int height)
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public int Width { get; } = width;
    public int Height { get; } = height;

    public void GenerateRoom(char[,] map)
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                map[Y + y, X + x] = '.';
            }
        }

    }
    
}