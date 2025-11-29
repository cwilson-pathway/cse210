class ListActivity : Activity
{
    private List<string> _prompts = [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ];
    private Random _random = new Random();
    private List<string> _userResponses = new List<string>();

    // Constructor
    public ListActivity(string name, string desc, int durSecs) : base(name, desc, durSecs) {}

    private void AddResponse(string text)
    {
        _userResponses.Add(text);
    }

    private string GetMainPrompt()
    {
        return _prompts[_random.Next(0, _prompts.Count - 1)];
    }

    private int GetNumItems()
    {
        return _userResponses.Count;
    }

    public void Run()
    {
        // Prep stage
        PrepStage();

        // Display welcome message and description.
        Console.WriteLine($"{GetWelcomeMessage()}\n{GetDesc()}");
        Console.WriteLine("\nConsider the following prompt: ");
        Console.WriteLine($"\n  --- {GetMainPrompt()} ---");
        Console.Write("\nPress Enter when you're ready: ");
        Console.ReadLine();

        // Countdown to main activity.
        Console.Write("\nGet ready to list in ");
        for (int seconds = 5; seconds > 0; seconds--)
        {
            Console.Write(seconds);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        Console.WriteLine();

        // Run until the time the user gave themselves runs out.
        DateTime futureTime = GetFutureTime();
        while (DateTime.Now < futureTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            AddResponse(response);
        }

        // End sequence.
        Console.WriteLine();
        _universalThrobber.Run();

        // Display how many items they've written and display the ending message.
        Console.WriteLine($"Wow! You've listed {GetNumItems()} things!\n\n{GetFinishingMessage()}");
        _universalThrobber.Run();

    }
}