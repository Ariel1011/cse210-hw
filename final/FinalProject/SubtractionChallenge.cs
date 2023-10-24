public class SubtractionChallenge : Challenge
{
    public SubtractionChallenge(string statement, int answer) : base(statement, answer) { }

    public override string GetStatement()
    {
        return $"{statement} (Subtraction Challenge)";
    }

    public override bool CheckAnswer(int userAnswer)
    {
        return userAnswer == answer;
    }
}