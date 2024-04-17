using System.Collections;
using System.Diagnostics;

namespace OOP_A2;

public static class Testing
{
    public static void RunTests()
    {
        Console.WriteLine("Running tests...");

        var die = new Die();
        List<int> rolls = [];

        for (int i = 0; i < 1000; i++)
        {
            die.Roll();
            Debug.Assert(die.Value is >= 1 and <= 6, $"Die value out of range. Value: {die.Value}");
            rolls.Add(die.Value);
        }
        Debug.Assert(rolls.Count == 1000, "Die roll count incorrect.");
        
        
        
        Game[] games =
        {
            new SevensOut(),
            new ThreeOrMore()
        };

        int resultSo = games[0].RunTest();
        Debug.Assert(resultSo == 7, $"Game ended unexpectedly. result: {resultSo}");
        
        int resultTom = games[1].RunTest();
        Debug.Assert(resultTom > 20 || resultTom != -1, $"Didn't end as expected. result: {resultTom}");
        
        string logPath = "../../../tests.log";
        using (StreamWriter sw = new StreamWriter(logPath))
        {
            sw.WriteLine(string.Join(", ", rolls));
            sw.WriteLine($"Roll count: {rolls.Count}");
            
            sw.WriteLine($"Sevens Out test result: {resultSo}");
            sw.WriteLine($"Three Or More test result: {resultTom}");
            
            
        }
        
        Console.WriteLine($"Tests complete! Output to file {logPath}");
    }
}