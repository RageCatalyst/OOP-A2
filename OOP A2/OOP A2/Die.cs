namespace OOP_A2;

public class Die
{
    private static Random _rnd = new Random();
    public int Value { get; private set; } = _rnd.Next(1, 7);
    
    public void Roll()
    {
        Value = _rnd.Next(1, 7);
    }
}
