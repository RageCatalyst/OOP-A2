namespace OOP_A2;

// Abstract class Game
public abstract class Game
{
    // Main method
    static void Main(string[] args)
    {
        // Array of games
        Game[] games =
        [
            new SevensOut(),
            new ThreeOrMore()
        ];

        // Displaying the list of games
        Console.WriteLine("\n################\n");
        Console.WriteLine("Games:");
        for (int i = 0; i < games.Length; i++)
        {
            Console.WriteLine($"[{i + 1}] - {games[i].Name}");
        }

        // Additional options
        Console.WriteLine("'r' to reset statistics.\n't' to run tests.\n\n################");

        // Selecting a game
        SelectGame(games);
    }
    
    // Method to select a game
    private static void SelectGame(Game[] games)
    {
        // input loop, if input incorrect restart
        while (true)
        {
            int gameChoice = 0;
            Console.WriteLine("\nSelect a game:");
            var choice = Console.ReadLine();
            // attempt to parse the choice to an integer
            try
            {
                // if the choice is not null, parse it to an integer
                if (choice != null) gameChoice = int.Parse(choice) - 1;
                // if the choice is not in the array, throw an exception
                games[gameChoice].PlayGame();
                break;
            }
            catch (Exception e)
            {
                // if the choice is not in the array, throw an exception
                Console.WriteLine($"Game number not found. Attempting extra options (Error: {e.Message})");
            }
            
            // Handling other options
            switch (choice)
            {
                case "r":
                    Statistics.ResetStats();
                    Console.WriteLine("Statistics reset.");
                    return;
                    
                case "t":
                    Console.WriteLine("Running Tests");
                    Testing.RunTests();
                    return;
                case "s":
                    Statistics.DisplayStats();
                    return;
                default:
                    Console.WriteLine("No extra choice with that alias.");
                    break;
            }
        }
    }
    
    // Properties
    public string Name { get; protected init; } = "";
    public int TimesPlayed { get; set; } = 0;
    public int HighScore { get; set; } = 0;

    // Abstract methods
    protected abstract void PlayGame();
    public abstract int RunTest();
}