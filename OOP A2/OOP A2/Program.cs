namespace OOP_A2;

class Program
{
    static void Main(string[] args)
    {
        Game[] games =
        [
            new SevensOut(),
            new ThreeOrMore()
        ];

        
        Console.WriteLine("\n################\n");
        for(int i = 0; i < games.Length; i++)
        {
            // Displays each game's name
            Console.WriteLine($"[{i+1}] - {games[i].Name}");

        }
    }
}