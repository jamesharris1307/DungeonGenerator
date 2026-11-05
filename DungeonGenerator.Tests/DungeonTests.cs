namespace DungeonGenerator.Tests;

using NUnit.Framework;

public class DungeonTests
{
    // Asserting that the constructor sets the correct dimensions of the Dungeon Map
    [Test]
    public void Constructor_SetsCorrectDimensions()
    {
        Dungeon dungeon = new Dungeon(10, 8);

        int width = dungeon.Width;
        int height = dungeon.Height;

        Assert.That(width, Is.EqualTo(10));
        Assert.That(height, Is.EqualTo(8));
    }

    // Asserting that the Constructor sets any non boundary cell is an empty
    [Test]
    public void Constructor_SetsCorrectInterior()
    {
        Dungeon dungeon = new Dungeon(10, 8);
        
        int width = dungeon.Width;
        int height = dungeon.Height;

        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                CellType cell = dungeon.GetCell(y, x);

                Assert.That(cell, Is.EqualTo(CellType.Empty));
            }
        }
    }
}