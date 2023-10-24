public class AdditionChallenge : Challenge
{
    public AdditionChallenge(string statement, int answer) : base(statement, answer) { }

    public override string GetStatement()
    {
        return $"{statement} (Addition Challenge)";
    }

    public override bool CheckAnswer(int userAnswer)
    {
    
        return Math.Abs(userAnswer - answer) <= 1;
    }
}
