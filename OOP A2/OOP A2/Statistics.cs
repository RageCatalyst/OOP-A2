namespace OOP_A2;
using Newtonsoft.Json;

public class Statistics
{
    public static void SaveStats(Game game)
    {
        // try read file (i've tried to do this with file.exists, it was not having it)
        try
        {
            File.ReadAllText("../../../stats.json");
        }
        catch (FileNotFoundException)
        {
            // if file not found, reset stats (create new stats file) 
            ResetStats();
        }
        
        // load the stats from a file
        var stats = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText("../../../stats.json"));

        // if stats is null, reset stats
        if (stats == null) ResetStats();
        // set the stats for the game
        stats[$"{game.Name} Total Plays"] = game.TimesPlayed;
        stats[$"{game.Name} High Score"] = game.HighScore;
        
        // save the stats to a file
        File.WriteAllText("../../../stats.json", JsonConvert.SerializeObject(stats));
    }
    
    public static void LoadStats(Game game)
    {
        try
        {
            File.ReadAllText("../../../stats.json");
        }
        catch (FileNotFoundException)
        {
            ResetStats();
        }
        //load the stats from a file
        var stats = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText("../../../stats.json"));
        if (stats == null) ResetStats();
        //set the stats for the game
        game.TimesPlayed = stats[$"{game.Name} Total Plays"];
        game.HighScore = stats[$"{game.Name} High Score"];
    }
    
    
    
    public static void ResetStats()
    {
        //reset the stats
        var stats = new Dictionary<string, int>
        {
            {"Sevens Out Total Plays", 0},
            {"Sevens Out High Score", 0},
            {"Three Or More Total Plays", 0},
            {"Three Or More High Score", 0}
        };
        
        // save the stats to a file
        var json = JsonConvert.SerializeObject(stats);
        File.WriteAllText("../../../stats.json", json);
    }

    public static void DisplayStats()
    {
        try
        {
            File.ReadAllText("../../../stats.json");
        }
        catch (FileNotFoundException)
        {
            ResetStats();
        }
        //load the stats from a file
        var stats = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText("../../../stats.json"));
        if (stats == null) ResetStats();
        
        //display the stats
        Console.WriteLine("Statistics:");
        foreach (var (key, value) in stats)
        {
            Console.WriteLine($"{key}: {value}");
        }
    }
}