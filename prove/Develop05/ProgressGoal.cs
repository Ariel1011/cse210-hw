public class ProgressGoal : Goal
{
    private int _progress;
    private int _target;

    public int Progress
    {
        get { return _progress; }
        set { _progress = value; }
    }

    public int Target
    {
        get { return _target; }
        set { _target = value; }
    }

    public ProgressGoal(string shortName, string description, int points, int target)
        : base(shortName, description, points)
    {
        _progress = 0;
        _target = target;
    }

    public override void RecordEvent()
    {
        _progress++;
    }

    public override bool IsComplete()
    {
        return _progress >= _target;
    }
}
