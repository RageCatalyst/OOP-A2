namespace OOP_A2;

public abstract class Game
{
    static void Main(string[] args)
    {

        Game[] games =
        [
            new SevensOut(),
            new ThreeOrMore()
        ];


        Console.WriteLine("\n################\n");
        for (int i = 0; i < games.Length; i++)
        {
            // Displays each game's name
            Console.WriteLine($"[{i + 1}] - {games[i].Name}");
        }

        Console.WriteLine("'r' to reset statistics.\n't' to run tests.\n\n################");

        SelectGame(games);
    }
    
    private static void SelectGame(Game[] games)
    {
        while (true)
        {
            int gameChoice = 0;
            // Asks the user to select a game
            Console.WriteLine("\nSelect a game:");
            var choice = Console.ReadLine();
            try
            {
                if (choice != null) gameChoice = int.Parse(choice) - 1;
                games[gameChoice].PlayGame();
                break;
            }
            catch
            {
                Console.WriteLine("Game number not found. Attempting extra options");
            }
            

            // other options
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
                default:
                    Console.WriteLine("No extra choice with that alias.");
                    break;
            }

            
            
        }
    }
    
    public string Name { get; protected init; } = "";
    public int TimesPlayed { get; set; } = 0;
    public int HighScore { get; set; } = 0;

    protected abstract void PlayGame();

    public abstract int RunTest();
}