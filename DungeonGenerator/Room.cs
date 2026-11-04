namespace DungeonGenerator;

public class Room
{
    public int Width { get; }
    public int Height { get; }
    
    public Room(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }
}