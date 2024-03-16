namespace OOP_A2;

public class ThreeOrMore : Game
{
    public ThreeOrMore()
    {
        Name = "Three Or More";
    }
    
    public override void PlayGame()
    {
        Die[] dice = new Die[5];
        for(int i = 0; i < dice.Length; i++)
        {
            dice[i] = new Die();
        }
        
        bool gameOver = false;

        
        while (!gameOver)
        {
            foreach (var t in dice)
            {
                t.Roll();
                Console.WriteLine($"Die {Array.IndexOf(dice, t) + 1}: {t.Value}");
            }

            var dieValues = CountDie(dice);

            foreach (var pair in dieValues)
            {
                if (pair.Value >= 2)
                {
                    Console.WriteLine($"You rolled a {pair.Key} {pair.Value} times!");
                }
            }
            
            // if play chooses, re-roll all die
            Console.WriteLine("Would you like to re-roll 'a'll dice or the 'r'emaining dice? (a/r)");
            var choice = Console.ReadLine();
            if (choice.ToLower() == "a") continue;

            else
            {
                // re-roll all remaining die (die with a count of 1)
                foreach (var pair in dieValues.Where(pair => pair.Value == 1))
                {
                    dice[Array.IndexOf(dice, dice.First(d => d.Value == pair.Key))].Roll();
                }
                
                foreach (var t in dice)
                {
                    Console.WriteLine($"Die {Array.IndexOf(dice, t) + 1}: {t.Value}");
                }
                
                // recount die
                dieValues = CountDie(dice);
                foreach (var pair in dieValues)
                {
                    if (pair.Value >= 2)
                    {
                        Console.WriteLine($"You rolled a {pair.Key} {pair.Value} times!");
                    }
                }
                
                // display highest frequency die value
                var max = dieValues.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                Console.WriteLine($"The highest frequency die value is {max} with {dieValues[max]}!");
                
                
            }

            gameOver = !gameOver;
        }
    }
    
    private static Dictionary<int, int> CountDie(Die[] dice)
    {
        var dict = new Dictionary<int, int>();
        foreach (var t in dice)
        {
            dict.TryGetValue(t.Value, out var count);
            dict[t.Value] = count + 1;
        }

        return dict;
    }
}