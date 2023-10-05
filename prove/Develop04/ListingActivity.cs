public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity(string name, string description, int duration, int count, List<string> prompts)
        : base(name, description, duration)
    {
        _count = count;
        _prompts = prompts;
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    public void Run()
    {
        DisplayStartingMessage();
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {randomPrompt}");
        List<string> userResponses = GetListFromUser();
        Console.WriteLine("User responses:");
        foreach (string response in userResponses)
        {
            Console.WriteLine(response);
        }
        DisplayEndingMessage();
    }

    public List<string> GetListFromUser()
    {
        List<string> userResponses = new List<string>();
        for (int i = 0; i < _count; i++)
        {
            Console.Write($"Enter item {i + 1}: ");
            string item = Console.ReadLine();
            userResponses.Add(item);
        }
        return userResponses;
    }
}
