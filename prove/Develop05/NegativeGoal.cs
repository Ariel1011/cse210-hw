public class NegativeGoal : Goal
{
    private int Penalty { get; set; }
    private GoalManager _goalManager;

    public NegativeGoal(string shortName, string description, int penalty, GoalManager goalManager)
        : base(shortName, description, 0)
    {
        Penalty = penalty;
        _goalManager = goalManager;
    }

    public void Violate()
    {
        if (_goalManager != null)
        {
            _goalManager.Score -= Penalty;
        }
    }

    public override bool IsComplete()
    {
        return false;
    }
}
