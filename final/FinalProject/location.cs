public class Location
{
    private string name;
    private string description;
    private string storyline;
    private bool hasChallenge;
    private Challenge challenge;

    public Location(string name, string description, string storyline)
    {
        this.name = name;
        this.description = description;
        this.storyline = storyline;
    }

    public void SetChallenge(Challenge challenge)
    {
        hasChallenge = true;
        this.challenge = challenge;
    }

    public string GetDescription()
    {
        return description;
    }

    public string GetStoryline()
    {
        return storyline;
    }

    public bool HasChallenge
    {
        get { return hasChallenge; }
    }

    public Challenge GetChallenge()
    {
        return challenge;
    }
}