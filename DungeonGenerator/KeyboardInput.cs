namespace DungeonGenerator;

public static class KeyboardInput
{
    public static void ProcessInput(Player player)
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    player.MoveUp();
                    break;
                
                case ConsoleKey.DownArrow:
                    player.MoveDown();
                    break;
                
                case ConsoleKey.LeftArrow:
                    player.MoveLeft();
                    break;
                
                case ConsoleKey.RightArrow:
                    player.MoveRight();
                    break;
            }
        }
    }
}