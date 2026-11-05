namespace DungeonGenerator;

// This Class handles:
/*
 - Assigning a symbol to the cell depending on the cell type
 - displaying the dungeon based off the cell data
 */

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
        // Loop through the rows
        for (int y = 0; y < dungeon.Height; y++)
        {
            // Loop the columns
            for (int x = 0; x < dungeon.Width; x++)
            {
                Console.Write(GetDisplayCharacter(dungeon.GetCell(y, x)));
            }

            Console.WriteLine();
        }
    }
}