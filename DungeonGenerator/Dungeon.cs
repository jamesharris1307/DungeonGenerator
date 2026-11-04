namespace DungeonGenerator;

public class Dungeon
{
    private readonly char[,] _map;

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
                    _map[y, x] = '.';
                }
            }
        }
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