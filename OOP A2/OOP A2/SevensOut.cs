namespace OOP_A2;

public class SevensOut : Game
{
    public SevensOut()
    {
        Name = "Sevens Out";
    }

    protected override void PlayGame()
    {
        // load the stats for this game
        Statistics.LoadStats(this);
        // increment the number of times played
        TimesPlayed += 1;
        
        Console.WriteLine("Playing Sevens Out!\n \n");
        // create two die
        Die[] dice = new Die[2];
        for(int i = 0; i < dice.Length; i++)
        {
            dice[i] = new Die();
        }
        
        // important variables
        bool gameOver = false;
        int total = 0;
        int j = 0;
        
        // game loop
        while(!gameOver)
        {
            
            Console.WriteLine($"Total = {total} \nPress Enter to roll again!");
            Console.ReadLine();
            
            // increment the roll count
            j++;
            
            // roll all die
            foreach (var t in dice)
            {
                t.Roll();
            }
            
            // display the values of both die
            Console.WriteLine($"Roll {j}: \nDie 1: {dice[0].Value} \nDie 2: {dice[1].Value} \n ");
            
            // check if either roll is 7
            gameOver = (dice[0].Value + dice[1].Value == 7);
            
            // add the total of the two die to the total, unless its a double, then double the total
            if(dice[0].Value == dice[1].Value)
            {
                total += (dice[0].Value + dice[1].Value) * 2;
            } else total += dice[0].Value + dice[1].Value;
            
            
        }
        Console.WriteLine($"Game Over! You rolled a total of 7! \nEnd Total: {total}\n \n");
        
        // check if the total is greater than the high score
        if (total > HighScore)
        {
            // if it is, set the high score to the total
            HighScore = total;
            Console.WriteLine("New High Score!");
        }
        
        // save the new stats
        Statistics.SaveStats(this);
    }
    
    public override int RunTest()
    {
        // important variables
        bool gameOver = false;
        int total = 0;
        int j = 0;
        int testResult = 0;

        // game loop
        while (!gameOver)
        {
            Console.WriteLine("Testing Sevens Out!\n \n");
            Die[] dice = new Die[2];
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = new Die();
            }
            j++;
            // roll both die
            foreach (var t in dice)
            {
                t.Roll();
            }

            // display the values of both die
            testResult = dice[0].Value + dice[1].Value;
            
            // check if either roll is 7
            gameOver = (dice[0].Value + dice[1].Value == 7);

            // add the total of the two die to the total, unless its a double, then double the total
            if (dice[0].Value == dice[1].Value)
            {
                total += (dice[0].Value + dice[1].Value) * 2;
            }
            else total += dice[0].Value + dice[1].Value;
            
        }

        // return the total
        Console.WriteLine("Test Complete");
        return testResult;
    }
}