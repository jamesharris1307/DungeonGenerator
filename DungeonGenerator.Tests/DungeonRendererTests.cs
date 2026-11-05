namespace DungeonGenerator.Tests;

public class DungeonRendererTests
{
    [Test]
    public void Display_RendersDungeonCorrectly()
    {
        Dungeon dungeon = new Dungeon(5, 5);
        DungeonRenderer renderer = new DungeonRenderer();

        TextWriter originalOutput = Console.Out;
        StringWriter output = new StringWriter();

        try
        {
            Console.SetOut(output);

            renderer.Display(dungeon);

            string expected =
                "#####" + Environment.NewLine +
                "#   #" + Environment.NewLine +
                "#   #" + Environment.NewLine +
                "#   #" + Environment.NewLine +
                "#####" + Environment.NewLine;

            Assert.That(output.ToString(), Is.EqualTo(expected));
        }
        // Always clean up so doesn't affect other tests even if test is failure or success
        finally
        {
            Console.SetOut(originalOutput);
            output.Dispose();
        }
    }
}