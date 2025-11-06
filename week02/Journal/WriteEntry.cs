using System;
class WriteEntry
{
    // Prompt the user from different prompts and store input.
    private static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "How did I overcome my weaknesses today?",
        "What good habits have I engaged in today?",
        "How has someone I know showed love to me?",
        "What's something that has happened that I'm grateful for?"
    };
    private static Random rand = new Random();
    public string _currentPrompt = prompts[rand.Next(0, prompts.Count - 1)];
    public string _textEntry = "";
    public DateTime _entryTime = DateTime.Now;

    // For testing purposes
    public void DisplayPrompts()
    {
        foreach (string line in prompts)
        {
            Console.WriteLine(line);
        }
    }
}