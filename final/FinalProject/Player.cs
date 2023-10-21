public class Player
{
    private string name;
    private int strength;
    private int intelligence;

    public Player(string name)
    {
        this.name = name;
        strength = 1;
        intelligence = 1;
    }

    public void UpdateAttributes(int attributeChange)
    {
        intelligence += attributeChange;
    }
}
