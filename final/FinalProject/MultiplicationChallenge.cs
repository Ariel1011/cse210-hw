public class MultiplicationChallenge : Challenge
{
    public MultiplicationChallenge(string statement, int answer) : base(statement, answer) { }

    public override string GetStatement()
    {
        return $"{statement} (Multiplication Challenge)";
    }

    public override bool CheckAnswer(int userAnswer)
    {
        return userAnswer == answer;
    }
}
