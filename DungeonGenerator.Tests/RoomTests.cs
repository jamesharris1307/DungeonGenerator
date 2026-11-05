
namespace DungeonGenerator.Tests;

using NUnit.Framework;

public class RoomTests
{
    [Test]
    public void Constructor_SetsCorrectCoordinates()
    {
        Room room = new Room(5, 10, 8, 6);

        int x = room.X;
        int y = room.Y;

        Assert.That(x, Is.EqualTo(5));
        Assert.That(y, Is.EqualTo(10));
    }

    [Test]
    public void Constructor_SetsCorrectDimensions()
    {
        Room room = new Room(5, 10, 8, 6);

        int width = room.Width;
        int height = room.Height;

        Assert.That(width, Is.EqualTo(8));
        Assert.That(height, Is.EqualTo(6));
    }

    [Test]
    public void CentreX_ReturnsCorrectCentreCoordinate()
    {
        Room room = new Room(5, 10, 8, 6);

        int centreX = room.CentreX;

        Assert.That(centreX, Is.EqualTo(9));
    }

    [Test]
    public void CentreY_ReturnsCorrectCentreCoordinate()
    {
        Room room = new Room(5, 10, 8, 6);

        int centreY = room.CentreY;

        Assert.That(centreY, Is.EqualTo(13));
    }

    [Test]
    public void GenerateRoom_CreatesCorrectWalls()
    {
        CellType[,] map = new CellType[20, 20];
        Room room = new Room(5, 5, 6, 6);

        room.GenerateRoom(map);

        for (int x = 0; x < room.Width; x++)
        {
            Assert.That(map[room.Y, room.X + x],
                Is.EqualTo(CellType.RoomWall));

            Assert.That(map[room.Y + room.Height - 1, room.X + x],
                Is.EqualTo(CellType.RoomWall));
        }

        for (int y = 0; y < room.Height; y++)
        {
            Assert.That(map[room.Y + y, room.X],
                Is.EqualTo(CellType.RoomWall));

            Assert.That(map[room.Y + y, room.X + room.Width - 1],
                Is.EqualTo(CellType.RoomWall));
        }
    }

    [Test]
    public void GenerateRoom_CreatesCorrectFloor()
    {
        CellType[,] map = new CellType[20, 20];
        Room room = new Room(5, 5, 6, 6);

        room.GenerateRoom(map);

        for (int y = 1; y < room.Height - 1; y++)
        {
            for (int x = 1; x < room.Width - 1; x++)
            {
                Assert.That(map[room.Y + y, room.X + x],
                    Is.EqualTo(CellType.RoomFloor));
            }
        }
    }
}
