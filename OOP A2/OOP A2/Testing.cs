using System.Collections;
using System.Diagnostics;

namespace OOP_A2;

public static class Testing
{
    public static void RunTests()
    {
        Console.WriteLine("Running tests...");

        // Test the die
        var die = new Die();
        List<int> rolls = [];

        // roll 1000 times
        for (int i = 0; i < 1000; i++)
        {
            die.Roll();
            Debug.Assert(die.Value is >= 1 and <= 6, $"Die value out of range. Value: {die.Value}");
            rolls.Add(die.Value);
        }
        // check dice was rolled 1000 times
        Debug.Assert(rolls.Count == 1000, "Die roll count incorrect.");
        
        
        // instantiate the two games
        Game[] games =
        {
            new SevensOut(),
            new ThreeOrMore()
        };

        // run the tests
        int resultSo = games[0].RunTest();
        // if result is 7, the game ended as expected
        Debug.Assert(resultSo == 7, $"Game ended unexpectedly. result: {resultSo}");
        
        // run the tests
        int resultTom = games[1].RunTest();
        // if result is greater than 20 or -1, the game ended as expected
        Debug.Assert(resultTom > 20 || resultTom != -1, $"Didn't end as expected. result: {resultTom}");
        
        // write the results to a file
        string logPath = "../../../tests.log";
        using (StreamWriter sw = new StreamWriter(logPath))
        {
            sw.WriteLine(string.Join(", ", rolls));
            sw.WriteLine($"Roll count: {rolls.Count}");
            
            sw.WriteLine($"Sevens Out test result: {resultSo}");
            sw.WriteLine($"Three Or More test result: {resultTom}");
            
            
        }
        
        // output the results
        Console.WriteLine($"Tests complete! Output to file {logPath}");
    }
}