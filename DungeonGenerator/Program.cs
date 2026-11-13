
namespace DungeonGenerator;

// This class acts as the entry point for the application
// It offers the user the main menu and accepts input from 
// the user in the form of integers.

enum GameState
{
    MainMenu,
    GamePlaying,
    GameOver,
}

internal static class Program
{
    private static bool _running = true;
 
    private static void Main()
    {
        var player = new Player(0, 0);
        
        while (_running)
        {
            KeyboardInput.ProcessInput(player);
            Render.Display(player);
            Thread.Sleep(16);
        }
    }
}
