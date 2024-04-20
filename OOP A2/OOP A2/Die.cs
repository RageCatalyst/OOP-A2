namespace OOP_A2;

public class Die
{
    // Random number generator
    private static Random _rnd = new Random();
    // Value of the die
    public int Value { get; private set; } = _rnd.Next(1, 7);
    
    // Method to roll the die
    public void Roll()
    {
        Value = _rnd.Next(1, 7);
    }
}
