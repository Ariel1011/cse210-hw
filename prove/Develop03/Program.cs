class Program
{
    static List<Scripture> scriptureLibrary = new List<Scripture>();
    static List<Scripture> memorizedScriptures = new List<Scripture>();

    static void Main(string[] args)
    {
        LoadScriptureLibrary("scripture_library.txt");

        Console.WriteLine("Get ready to embark on a journey of spiritual growth with the Scripture Memorization Challenge!");

        while (true)
        {
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Memorize a scripture");
            Console.WriteLine("2. View memorization statistics");
            Console.WriteLine("3. Quit");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        MemorizeScripture();
                        break;
                    case 2:
                        ViewMemorizationStatistics();
                        break;
                    case 3:
                        Console.WriteLine("Thank you for using the Scripture Memorization Challenge!");
                        return;
                    default:
                        Console.WriteLine("Invalid Selection. Please select a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid choice.");
            }
        }
    }
    // Exceeding Requirements:
    // - Implemented a feature to load a library of scriptures from an external file.
    // - Provided the ability for users to select and memorize specific scriptures from the library.
    // - Added a feature to display memorization statistics, including the total number of scriptures and memorized scriptures.
    // - Ensured a structured class design with encapsulation and clear separation of concerns.
    // - Created a user-friendly menu interface for easy navigation
    static void MemorizeScripture()
    {
        Console.WriteLine("Select a scripture to memorize:");

        for (int i = 0; i < scriptureLibrary.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptureLibrary[i].Reference.GetDisplayText()}");
        }

        int selectedScriptureIndex;

        while (true)
        {
            Console.Write("Enter the number of the scripture to memorize (or '0' to go back): ");
            if (int.TryParse(Console.ReadLine(), out selectedScriptureIndex) &&
                selectedScriptureIndex >= 0 && selectedScriptureIndex <= scriptureLibrary.Count)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid scripture number or '0' to go back.");
            }
        }

        if (selectedScriptureIndex == 0)
        {
            Console.WriteLine("Going back to the main menu.");
            return;
        }

        var selectedScripture = scriptureLibrary[selectedScriptureIndex - 1];

        Console.WriteLine($"You have chosen to memorize: {selectedScripture.Reference.GetDisplayText()}");
        Console.WriteLine("Press Enter to start memorizing or type 'quit' to finish.");

        bool wordsHidden = false;

        while (true)
        {
            var input = Console.ReadLine().ToLower();
            if (input == "quit")
            {
                Console.WriteLine("Thanks for memorizing!");
                memorizedScriptures.Add(selectedScripture);
                break;
            }

            if (!selectedScripture.IsCompletelyHidden())
            {
                selectedScripture.HideRandomWords(1);

                Console.Clear();
                Console.WriteLine($"Scripture Verse ({selectedScripture.Reference.GetDisplayText()}):");

                DisplayScripture(selectedScripture, wordsHidden);

                if (selectedScripture.IsCompletelyHidden())
                {
                    Console.WriteLine("Congratulations! You've memorized the scripture.");
                    Console.WriteLine("Press Enter to exit.");
                    break;
                }
            }
        }
    }

    static void ViewMemorizationStatistics()
    {
        Console.WriteLine("Memorization Statistics:");
        Console.WriteLine($"Total number of scriptures: {scriptureLibrary.Count}");
        Console.WriteLine($"Number of scriptures memorized: {memorizedScriptures.Count}");
        Console.WriteLine("List of memorized scriptures:");

        foreach (var scripture in memorizedScriptures)
        {
            Console.WriteLine(scripture.Reference.GetDisplayText());
        }

        double memorizationPercentage = (double)memorizedScriptures.Count / scriptureLibrary.Count * 100;
        Console.WriteLine($"Memorization progress: {memorizationPercentage:F2}%");
    }

    static void DisplayScripture(Scripture scripture, bool wordsHidden)
    {
        string verseText = scripture.GetChallengeText(wordsHidden);
        Console.WriteLine(verseText);
    }

    static void LoadScriptureLibrary(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                if (parts.Length >= 2)
                {
                    string referenceText = parts[0].Trim();
                    string scriptureText = parts[1].Trim();
                    Reference reference = Reference.Parse(referenceText);
                    scriptureLibrary.Add(new Scripture(reference, scriptureText));
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error loading scripture library: " + e.Message);
        }
    }
}

