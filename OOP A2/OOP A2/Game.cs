namespace OOP_A2;

public abstract class Game
{
    public string Name { get; protected set; } = "";
    
    public abstract void PlayGame();
}