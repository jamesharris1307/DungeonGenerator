namespace DungeonGenerator;

public class Render
{
    public static void Display(Player player)
    {   Console.Clear();
        Console.WriteLine("X = " + player.XPos + " : " + "Y = " + player.YPos);
    }
}