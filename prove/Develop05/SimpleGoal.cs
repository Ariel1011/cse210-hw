public class SimpleGoal : Goal
{
    public SimpleGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    { }

    public override bool IsComplete()
    {
        return false;
    }
}
