namespace OOP_A2;
using Newtonsoft.Json;

public class Statistics
{
    public static void SaveStats(Game game)
    {
        try
        {
            File.ReadAllText("../../../stats.json");
        }
        catch (FileNotFoundException)
        {
            ResetStats();
        }
        
        var stats = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText("../../../stats.json"));

        if (stats == null) ResetStats();
        stats[$"{game.Name} Total Plays"] = game.TimesPlayed;
        stats[$"{game.Name} High Score"] = game.HighScore;
        

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
        
        Console.WriteLine("Statistics:");
        foreach (var (key, value) in stats)
        {
            Console.WriteLine($"{key}: {value}");
        }
    }
}