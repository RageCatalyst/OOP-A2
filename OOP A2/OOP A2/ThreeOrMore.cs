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
            
            foreach (var t in dice)
            {
                
                //check if any dice are the same
                if (dice.Count(x => x.Value == t.Value) >= 2)
                {
                    Console.WriteLine($"you rolled more than one {t.Value}! Game Over!");
                    break;
                }
            }

            gameOver = !gameOver;
        }
        
        
        
        
    }
}