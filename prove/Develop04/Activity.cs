public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    private void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine(_description);
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        Thread.Sleep(3000);
        ShowSpinner(3);
    }

    private void DisplayEndingMessage()
    {
        Console.WriteLine("Well done! You've completed the activity.");
        Console.WriteLine($"Activity: {_name}");
        Console.WriteLine($"Duration: {_duration} seconds");
        Thread.Sleep(3000);
    }

    protected virtual void PerformActivity()
    {
    
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinnerFrames = { "-", "\\", "|", "/" };
        int frameIndex = 0;

        for (int i = 0; i < seconds; i++)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write($"{spinnerFrames[frameIndex]}");
            Thread.Sleep(250);


            frameIndex = (frameIndex + 1) % spinnerFrames.Length;
        }

        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.CursorTop);
    }
}
