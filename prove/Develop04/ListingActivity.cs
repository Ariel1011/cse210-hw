public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<string> _usedPrompts; 

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _usedPrompts = new List<string>(); // Initialize used prompts list
    }

    protected override void PerformActivity()
    {
        string selectedPrompt = GetRandomPrompt();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"{selectedPrompt}");

        Console.WriteLine("You may begin in:");
        for (int i = 3; i > 0; i--)
        {
            Console.WriteLine($"Countdown: {i}");
            Thread.Sleep(1000);
        }

        Console.WriteLine("Please make sure to take your time and think deeply about each question.");

        List<string> itemsList = GetListFromUser();
        _count = itemsList.Count;

        Console.WriteLine($"You have listed {_count} items.");
        Console.WriteLine($"Total duration: {_duration} seconds");

    }

    private string GetRandomPrompt()
    {
        if (_usedPrompts.Count == _prompts.Count)
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

    private List<string> GetListFromUser()
    {
        List<string> itemsList = new List<string>();

        Console.WriteLine("Start listing items...");

        while (_count < _duration)
        {
            Console.Write($"> {_count + 1}: ");
            string item = Console.ReadLine();
            itemsList.Add(item);
            _count++;

            if (_count == _duration)
                break;
        }

        return itemsList;
    }
}
