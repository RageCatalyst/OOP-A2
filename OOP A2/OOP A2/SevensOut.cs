namespace OOP_A2;

public class SevensOut : Game
{
    public SevensOut()
    {
        Name = "Sevens Out";
    }
    
    public override void PlayGame()
    {
        Statistics.LoadStats(this);
        TimesPlayed += 1;
        
        Console.WriteLine("Playing Sevens Out!\n \n");
        Die[] dice = new Die[2];
        for(int i = 0; i < dice.Length; i++)
        {
            dice[i] = new Die();
        }
        
        bool gameOver = false;
        int total = 0;
        int j = 0;
        
        while(!gameOver)
        {
            
            Console.WriteLine($"Total = {total} \nPress Enter to roll again!");
            Console.ReadLine();
            
            j++;
            // roll both die
            foreach (var t in dice)
            {
                t.Roll();
            }
            
            // display the values of both die
            Console.WriteLine($"Roll {j}: \nDie 1: {dice[0].Value} \nDie 2: {dice[1].Value} \n ");
            
            // check if either roll is 7
            gameOver = (dice[0].Value + dice[1].Value == 7);
            
            if(dice[0].Value == dice[1].Value)
            {
                total += (dice[0].Value + dice[1].Value) * 2;
            } else total += dice[0].Value + dice[1].Value;
            
            
        }
        Console.WriteLine($"Game Over! You rolled a total of 7! \nEnd Total: {total}\n \n");
        
        if (total > HighScore)
        {
            HighScore = total;
            Console.WriteLine("New High Score!");
        }
        
        Statistics.SaveStats(this);
    }
    
    public override int RunTest()
    {
        bool gameOver = false;
        int total = 0;
        int j = 0;
        int testResult = 0;

        while (!gameOver)
        {
            Console.WriteLine("Playing Sevens Out!\n \n");
            Die[] dice = new Die[2];
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = new Die();
            }

            Console.WriteLine($"Total = {total} \nPress Enter to roll again!");
            Console.ReadLine();

            j++;
            // roll both die
            foreach (var t in dice)
            {
                t.Roll();
            }

            // display the values of both die
            Console.WriteLine($"Roll {j}: \nDie 1: {dice[0].Value} \nDie 2: {dice[1].Value} \n ");

            testResult = dice[0].Value + dice[1].Value;
            
            // check if either roll is 7
            gameOver = (dice[0].Value + dice[1].Value == 7);

            if (dice[0].Value == dice[1].Value)
            {
                total += (dice[0].Value + dice[1].Value) * 2;
            }
            else total += dice[0].Value + dice[1].Value;
        }

        return testResult;
    }
}