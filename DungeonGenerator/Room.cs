namespace DungeonGenerator;

public class Room(int x, int y, int width, int height)
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public int Width { get; } = width;
    public int Height { get; } = height;
    public int CentreX => X + Width / 2;
    public int CentreY => Y + Height / 2;

    public void GenerateRoom(CellType[,] map)
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (y == 0 || y == Height - 1 ||
                    x == 0 || x == Width - 1)
                {
                    map[Y + y, X + x] = CellType.RoomWall;
                }
                else
                {
                    map[Y + y, X + x] = CellType.RoomFloor;
                }
            }
        }
    }
}