public class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public string ShortName
    {
        get { return _shortName; }
        set
        {
            _shortName = value;
        }
    }

    public string Description
    {
        get { return _description; }
        set
        {
            _description = value;
        }
    }

    public int Points
    {
        get { return _points; }
        set
        {
            _points = value;
        }
    }

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public virtual void RecordEvent()
    {
    }

    public virtual bool IsComplete()
    {

        return false;
    }

    public virtual string GetDetailsString()
    {
        return $"{_shortName} - {_description} ({_points} points)";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{_shortName} - {_points} points";
    }
}
