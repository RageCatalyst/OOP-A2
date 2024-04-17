using System.Runtime.CompilerServices;

namespace OOP_A2;

public class ThreeOrMore : Game
{
    public ThreeOrMore()
    {
        Name = "Three Or More";
    }

    protected override void PlayGame()
    {
        int turn = 0;
        int[] playerScores = [0, 0];
        
        Statistics.LoadStats(this);
        TimesPlayed += 1;
        
        Die[] dice = new Die[5];
        for(int i = 0; i < dice.Length; i++)
        {
            dice[i] = new Die();
        }
        
        //while no score is greater than 20 using LINQ
        while(playerScores.All(score => score < 20))
        {
            Console.WriteLine($"Player {turn + 1}'s turn!");
            turn = PlayerTurn(turn, playerScores, dice);
        }
        
        if(playerScores[0] > playerScores[1])
        {
            Console.WriteLine("Player 1 wins!");
        } else if(playerScores[0] < playerScores[1])
        {
            Console.WriteLine("Player 2 wins!");
        } else
        {
            Console.WriteLine("It's a tie!");
        }
        
        Statistics.SaveStats(this);
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

    public override int RunTest()
    {   
        int turn = 0;
        int[] playerScores = [0, 0];
        
        Statistics.LoadStats(this);
        TimesPlayed += 1;
        
        Die[] dice = new Die[5];
        for(int i = 0; i < dice.Length; i++)
        {
            dice[i] = new Die();
        }
        
        //while no score is greater than 20 using LINQ
        while(playerScores.All(score => score < 20))
        {
            turn = PlayerTurn(turn, playerScores, dice);
        }
        
        if(playerScores[0] > playerScores[1])
        {
            return playerScores[0];
        } else if(playerScores[0] < playerScores[1])
        {
            return playerScores[0];

        } else
        {
            return -1;
        }
    }

    private int PlayerTurn(int turn, int[] playerScores, Die[] dice)
    {
        
        bool turnOver = false;

        
        while (!turnOver)
        {
            foreach (var t in dice)
            {
                t.Roll();
                Console.WriteLine($"Die {Array.IndexOf(dice, t) + 1}: {t.Value}");
            }

            var dieValues = CountDie(dice);

            foreach (var pair in dieValues.Where(pair => pair.Value >= 2))
            {
                Console.WriteLine($"You rolled a {pair.Key} {pair.Value} times!");
            }
            
            // if play chooses, re-roll all die
            Console.WriteLine("Would you like to re-roll 'a'll dice or the 'r'emaining dice? (a/r)");
            var choice = Console.ReadLine();
            if (choice?.ToLower() == "a") continue;

            Console.WriteLine("re-rolling remaining die...");
            
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
            Console.WriteLine($"The highest frequency die value is {max} with {dieValues[max]} occurrences!");
            switch (dieValues[max])
            {
                case 3:
                    Console.WriteLine("\nYou got a 3-of-a-kind! +3\n");
                    playerScores[turn] += 3;
                    break;
                case 4:
                    Console.WriteLine("\nYou got a 4-of-a-kind! +6\n");
                    playerScores[turn] += 6;
                    break;
                case 5:
                    Console.WriteLine("\nYou got a 5-of-a-kind! +12\n");
                    playerScores[turn] += 12;
                    break;
                default:
                    Console.WriteLine("\nYou need a 3-of-a-kind or better to gain any points! +0\n");
                    break;
            }
                
                
            Console.WriteLine($"Turn score: {playerScores[turn]}\n");
            
            if (playerScores[turn] > HighScore)
            {
                HighScore = playerScores[turn];
                Console.WriteLine("New High Score!");
            }
            
            turnOver = true;
            turn += 1;
            turn %= 2;
        }

        return playerScores[turn];
    }
    
}