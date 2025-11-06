using System;
using System.Runtime.CompilerServices;
class DisplayEntries
{
    // Display entries saved in Program.cs.
    public List<List<string>> _entries = new List<List<string>>();
    public List<List<string>> _loadedEntries = new List<List<string>>();
    const int timeIndex = 0;
    const int promptIndex = 1;
    const int textIndex = 2;

    public void Display()
    {
        foreach (List<string> entry in _loadedEntries)
        {
            Console.WriteLine($"{entry[timeIndex]}, Prompt: {entry[promptIndex]} \nEntry: {entry[textIndex]}");
        }
        foreach (List<string> entry in _entries)
        {
            Console.WriteLine($"{entry[timeIndex]}, Prompt: {entry[promptIndex]} \nEntry: {entry[textIndex]}");
        }
        
        if (_loadedEntries.Count == 0 && _entries.Count == 0)
        {
            Console.WriteLine("No entries found. Please add entries or load them from a file.");
        }
    }
}