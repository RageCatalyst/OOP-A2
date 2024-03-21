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

        Console.WriteLine("'r' to reset statistics.\n't' to run tests.\n\n################\n");
        // Asks the user to select a game
        Console.WriteLine("\nSelect a game:");
        var choice = Console.ReadLine();
        // Plays the selected game
        if(int.TryParse(choice, out _))
            games[int.Parse(choice) - 1].PlayGame();
        
        // other options
        switch(choice)
        {
            case "r":
                Statistics.ResetStats();
                Console.WriteLine("Statistics reset.");
                break;
            case "t":
                Console.WriteLine("Running Tests");
                Testing.RunTests();
                break;
        }
        
    }
}