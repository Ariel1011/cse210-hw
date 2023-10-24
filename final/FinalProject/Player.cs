public class Player
{
    private string name;
    private int strength;
    private int intelligence;
    private double score;

    public Player(string name)
    {
        this.name = name;
        strength = 1;
        intelligence = 1;
        score = 0; 
    }

    public void UpdateAttributes(int attributeChange)
    {
        intelligence += attributeChange;
    }

    public void UpdateScore(double scoreChange)
    {
        score = Math.Max(0, Math.Min(100, score + scoreChange));
    }

    public double GetScore()
    {
        return score;
    }
}
