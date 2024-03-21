using System.Collections;
using System.Diagnostics;

namespace OOP_A2;

public class Testing
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
        
        int result = games[0].RunTest();
        Debug.Assert(result == 7, $"Didn't end as expected. result: {result}");
        
        
        
        
        Console.WriteLine("Tests complete!");
    }
}