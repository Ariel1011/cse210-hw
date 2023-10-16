public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public int AmountCompleted
    {
        get { return _amountCompleted; }
        set
        {
            _amountCompleted = value;
        }
    }

    public int Target
    {
        get { return _target; }
        set
        {
            _target = value;
        }
    }

    public int Bonus
    {
        get { return _bonus; }
        set
        {
            _bonus = value;
        }
    }

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;

    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} ({_amountCompleted}/{_target} completed)";
    }
}
