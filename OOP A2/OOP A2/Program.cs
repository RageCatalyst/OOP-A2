namespace OOP_A2;

class Program
{
    static void Main(string[] args)
    {
        for(int i = 0; i < 1000; i++)
        {
            Die die = new Die();
            die.Roll();
            Console.WriteLine(die.Value);
        }
    }
}