
namespace DungeonGenerator;

// This Class handles the procedural generation of a dungeon

public class ProceduralDungeonGenerator
{
    private readonly Random _random = new();

    public Dungeon Generate(int width, int height, int roomCount)
    {
        Dungeon dungeon = new Dungeon(width, height);

        for (int i = 0; i < roomCount; i++)
        {
            // Generate random room dimensions
            int roomWidth = _random.Next(5, 15);
            int roomHeight = _random.Next(5, 15);

            // Attempt to place room.
            bool placed = dungeon.PlaceRandomRoom(roomWidth, roomHeight);

            if (!placed)
            {
                Console.WriteLine($"Could not place room {i + 1}.");
            }
        }

        // Connect the generated rooms
        dungeon.ConnectRooms();
        return dungeon;
    }
}