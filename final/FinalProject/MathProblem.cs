public class MathProblem
{
    private string statement;
    private int answer;

    public MathProblem(string statement, int answer)
    {
        this.statement = statement;
        this.answer = answer;
    }

    public string GetStatement()
    {
        return statement;
    }

    public bool CheckAnswer(int userAnswer)
    {
        return userAnswer == answer;
    }
}
