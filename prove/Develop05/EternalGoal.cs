public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    { }

    public override bool IsComplete()
    {
        return false;
    }
}
