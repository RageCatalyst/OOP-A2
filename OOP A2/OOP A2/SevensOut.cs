namespace OOP_A2;

public class SevensOut : Game
{
    public SevensOut()
    {
        Name = "Sevens Out";
    }
    
    public override int PlayGame()
    {
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
            
            total += dice[0] == dice[1] ? (dice[0].Value + dice[1].Value) * 2 : dice[0].Value + dice[1].Value;
        }
        Console.WriteLine($"Game Over! You rolled a total of 7! \nEnd Total: {total}\n \n");
        
        return total;

        
    }
}