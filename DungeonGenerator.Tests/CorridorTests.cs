
namespace DungeonGenerator.Tests;

using NUnit.Framework;

public class CorridorTests
{
    // Test the corridor sets the floor cells correctly
    [Test]
    public void ConnectRooms_CreatesCorridorFloors()
    {
        Dungeon dungeon = new Dungeon(40, 40);

        dungeon.PlaceRandomRoom(5, 5);
        dungeon.PlaceRandomRoom(5, 5);

        dungeon.ConnectRooms();

        bool corridorExists = false;

        for (int y = 1; y < dungeon.Height - 1; y++)
        {
            for (int x = 1; x < dungeon.Width - 1; x++)
            {
                if (dungeon.GetCell(y, x) == CellType.CorridorFloor)
                {
                    corridorExists = true;
                }
            }
        }

        Assert.That(corridorExists, Is.True);
    }

    // Test the corridor sets the walls correctly
    [Test]
    public void ConnectRooms_CreatesCorridorWalls()
    {
        Dungeon dungeon = new Dungeon(40, 40);

        dungeon.PlaceRandomRoom(5, 5);
        dungeon.PlaceRandomRoom(5, 5);

        dungeon.ConnectRooms();

        bool corridorWallsExist = false;

        for (int y = 1; y < dungeon.Height - 1; y++)
        {
            for (int x = 1; x < dungeon.Width - 1; x++)
            {
                if (dungeon.GetCell(y, x) == CellType.CorridorWall)
                {
                    corridorWallsExist = true;
                }
            }
        }

        Assert.That(corridorWallsExist, Is.True);
    }

    // Test when connecting rooms with a corridor that they don't overlay
    // (Can't have a corridor in a room)
    [Test]
    public void ConnectRooms_DoesNotOverwriteBoundaries()
    {
        Dungeon dungeon = new Dungeon(40, 40);

        dungeon.ConnectRooms();

        for (int x = 0; x < dungeon.Width; x++)
        {
            Assert.That(dungeon.GetCell(0, x), Is.EqualTo(CellType.Boundary));
            Assert.That(dungeon.GetCell(dungeon.Height - 1, x), Is.EqualTo(CellType.Boundary));
        }

        for (int y = 0; y < dungeon.Height; y++)
        {
            Assert.That(dungeon.GetCell(y, 0), Is.EqualTo(CellType.Boundary));
            Assert.That(dungeon.GetCell(y, dungeon.Width - 1), Is.EqualTo(CellType.Boundary));
        }
    }

    // Test that an error isn't thrown if no rooms exists
    // (Can't connect two rooms if no rooms exist)
    [Test]
    public void ConnectRooms_DoesNotThrow_WhenNoRoomsExist()
    {
        Dungeon dungeon = new Dungeon(40, 40);

        Assert.DoesNotThrow(() => dungeon.ConnectRooms());
    }

    // Test that an error isn't thrown if only 1 room exists
    // (Can't connect two rooms if only one room exists)
    [Test]
    public void ConnectRooms_DoesNotThrow_WhenOneRoomExists()
    {
        Dungeon dungeon = new Dungeon(40, 40);
        dungeon.PlaceRandomRoom(5, 5);

        Assert.DoesNotThrow(() => dungeon.ConnectRooms());
    }
}
