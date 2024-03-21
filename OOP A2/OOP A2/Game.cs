namespace OOP_A2;

public abstract class Game
{
    public string Name { get; protected init; } = "";
    public int TimesPlayed { get; set; } = 0;
    public int HighScore { get; set; } = 0;
    
    public abstract void PlayGame();

    public abstract int RunTest();
}