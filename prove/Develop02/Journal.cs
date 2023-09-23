using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {

                writer.WriteLine("Date,Prompt,EntryText");

                foreach (var entry in _entries)
                {

                    string date = $"\"{entry.Date}\"";
                    string prompt = $"\"{entry.PromptText}\"";
                    string entryText = $"\"{entry.EntryText}\"";
                    writer.WriteLine($"{date},{prompt},{entryText}");
                }
            }
            Console.WriteLine("Journal saved successfully as CSV.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            _entries.Add(new Entry(parts[0], parts[1], parts[2]));
                        }
                    }
                }
                Console.WriteLine("Journal loaded successfully from CSV.");
            }
            else
            {
                Console.WriteLine("File not found. The journal is empty.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }


}
