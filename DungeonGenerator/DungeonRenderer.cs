namespace DungeonGenerator;

public class DungeonRenderer
{
    // Convert cell types into their ASCII characters
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

    // Display the dungeon
    public void Display(Dungeon dungeon)
    {
        for (int y = 0; y < dungeon.Height; y++)
        {
            for (int x = 0; x < dungeon.Width; x++)
            {
                Console.Write(GetDisplayCharacter(dungeon.GetCell(y, x)));
            }

            Console.WriteLine();
        }
    }
}