public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void CreateGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void RecordEvent(string goalShortName)
    {
        var goal = _goals.FirstOrDefault(g => g.ShortName == goalShortName);
        if (goal != null)
        {
            goal.RecordEvent();
            _score += goal.Points;

            if (goal.IsComplete())
            {
                Console.WriteLine($"Goal '{goal.ShortName}' is complete!");
                _score += goal.Points;
            }
        }
    }

    public int GetScore()
    {
        return _score;
    }

    public void SaveGoals(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine($"{goal.GetType().Name}|{goal.ShortName}|{goal.Description}|{goal.Points}");
            }
        }
    }

    public void LoadGoals(string fileName)
    {
        _goals.Clear();
        _score = 0;

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 4)
                {
                    string typeName = parts[0];
                    string shortName = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    Goal goal = null;
                    if (typeName == "SimpleGoal")
                    {
                        goal = new SimpleGoal(shortName, description, points);
                    }
                    else if (typeName == "EternalGoal")
                    {
                        goal = new EternalGoal(shortName, description, points);
                    }
                    else if (typeName == "ChecklistGoal")
                    {
                        int target = 0;
                        int bonus = 0;
                        // Parse target and bonus if available
                        if (parts.Length > 4)
                        {
                            target = int.Parse(parts[4]);
                            bonus = int.Parse(parts[5]);
                        }
                        goal = new ChecklistGoal(shortName, description, points, target, bonus);
                    }

                    if (goal != null)
                    {
                        _goals.Add(goal);
                    }
                }
            }
        }
    }
}
