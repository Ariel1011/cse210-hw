public class Location
{
    private string name;
    private string description;
    private bool hasChallenge;
    private MathProblem challenge;

    public Location(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void SetChallenge(MathProblem problem)
    {
        hasChallenge = true;
        challenge = problem;
    }

    public string GetDescription()
    {
        return description;
    }

    public bool HasChallenge
    {
        get { return hasChallenge; }
    }

    public MathProblem GetChallenge()
    {
        return challenge;
    }
}
