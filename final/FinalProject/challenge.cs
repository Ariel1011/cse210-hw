public class Challenge
{
    protected string statement;
    protected int answer;

    public Challenge(string statement, int answer)
    {
        this.statement = statement;
        this.answer = answer;
    }

    public virtual string GetStatement()
    {
        return statement;
    }

    public virtual bool CheckAnswer(int userAnswer)
    {
        return userAnswer == answer;
    }
}
