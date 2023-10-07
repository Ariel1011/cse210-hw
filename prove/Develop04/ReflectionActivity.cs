public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _usedPrompts;

    public ReflectionActivity()
        : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _usedPrompts = new List<string>();
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Consider the following prompt:");
        string selectedPrompt = GetRandomPrompt();
        Console.WriteLine($"{selectedPrompt}");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.WriteLine();

        Console.WriteLine("You may begin in:");
        for (int i = 3; i > 0; i--)
        {
            Console.WriteLine($"{i}");
            Thread.Sleep(1000);
        }

        Console.WriteLine("Please make sure to take your time and think deeply about each question.");

        string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        int totalDuration = _duration;

        while (totalDuration > 0)
        {
            foreach (string question in questions)
            {
                Console.WriteLine(question);
                Thread.Sleep(5000);
                ShowSpinner(5);
                totalDuration -= 5;

                if (totalDuration <= 0)
                    break;
            }
        }

        Console.WriteLine($"You have completed reflecting on the experience related to '{selectedPrompt}'.");
        Console.WriteLine($"Total duration: {_duration} seconds");
    }

    private string GetRandomPrompt()
    {
        if (!_prompts.Except(_usedPrompts).Any())
        {
            _usedPrompts.Clear();
        }

        Random random = new Random();
        string randomPrompt;

        do
        {
            int randomIndex = random.Next(_prompts.Count);
            randomPrompt = _prompts[randomIndex];
        } while (_usedPrompts.Contains(randomPrompt));

        _usedPrompts.Add(randomPrompt);

        return randomPrompt;
    }
}
