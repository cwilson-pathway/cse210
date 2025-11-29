class ReflectionActivity : Activity
{
    private List<string> _mainPrompts = new List<string>([
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
    ]);
    private List<string> _subPrompts = new List<string>([
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ]);

    private Random _random = new Random();

    // Constructor
    public ReflectionActivity(string name, string desc, int durSecs) : base(name, desc, durSecs) {}

    private string GetMainPrompt()
    {
        return _mainPrompts[_random.Next(0, _mainPrompts.Count - 1)];
    }

    private string GetSubPrompt()
    {
        return _subPrompts[_random.Next(0, _subPrompts.Count - 1)];
    }

    public void Run()
    {
        // Prepare stage
        PrepStage();

        // Display main prompt, ask user to hit enter to continue.
        Console.WriteLine($"{GetWelcomeMessage()}\n{GetDesc()}\n");
        Console.WriteLine($"Consider the following: \n\n  --- {GetMainPrompt()} ---");
        Console.Write("\nOnce you have something in mind, press enter to continue. ");
        Console.ReadLine();

        // Countdown to main activity.
        Console.Write("\nPonder the following questions in ");
        for (int seconds = 5; seconds > 0; seconds--)
        {
            Console.Write(seconds);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        Console.Clear();

        // Show the random subprompt and make a new throbber item that lasts 10 seconds.
        // initialSubPrompts is a derived list that will remove its entries for each time they are accessed,
        // ensuring that no two prompts are rewritten. 
        List<string> initialSubPrompts = _subPrompts;
        Throbber promptThrobber = new Throbber(10);
        promptThrobber.EnableNewLine();
        DateTime futureTime = GetFutureTime();
        while (initialSubPrompts.Count > 0 && DateTime.Now < futureTime)
        {
            string prompt = initialSubPrompts[_random.Next(0, initialSubPrompts.Count - 1)];
            Console.Write($"{prompt} ");
            promptThrobber.Run();
            initialSubPrompts.Remove(prompt);
        }

        // Run _universalThrobber and display the exit message. 
        Console.WriteLine();
        _universalThrobber.Run();
        Console.Write($"{GetFinishingMessage()} ");
        _universalThrobber.Run();

    }
}