using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "What is my overall intention for this day?",
            "What was the best part of your day?",
            "How did you see the hand of the Lord in your life today?",
            "What do I need to be mindful of today?",
            "What did you learn today?"
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
