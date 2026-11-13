namespace DungeonGenerator;

public class Player (int yPos, int xPos)
{
    public int YPos { get; set; } = yPos;
    public int XPos { get; set; } = xPos;

    public void MoveUp()
    {
        YPos += 1;
    }

    public void MoveDown()
    {
        YPos -= 1;
    }

    public void MoveLeft()
    {
        XPos -= 1;
    }

    public void MoveRight()
    {
        XPos += 1;
    }
}