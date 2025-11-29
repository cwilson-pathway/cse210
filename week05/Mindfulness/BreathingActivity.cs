class BreathingActivity : Activity
{
    // Setting reference vars
    private int _inhaleDuration;
    private int _inhaleHoldDuration;
    private int _exhaleDuration;
    private int _exhaleHoldDuration;
    private int _reps;
    private Throbber _holdThrobber = new Throbber();

    // Receives activity name, desc, and timing for exercise quadrants inhale, hold, exhale, hold. Sends name, desc and the product of the sum of
    // the exercise quadrants and number of reps.
    public BreathingActivity(string name, string desc, int inhale, int inhaleHold, int exhale, int exhaleHold, int reps) 
    : base(name, desc, (inhale + inhaleHold + exhale + exhaleHold) * reps)
    {
        _inhaleDuration = inhale;
        _inhaleHoldDuration = inhaleHold;
        _exhaleDuration = exhale;
        _exhaleHoldDuration = exhaleHold;
        _reps = reps;
    }

    private void ClearConsoleLine(string currentString)
    {
        // Adds one to currentString.Length because of a visual bug that kept a pipe in column 1.
        for (int charIndex = 0; charIndex < currentString.Length + 1; charIndex++)
        {
            Console.Write("\b");
        }
        for (int charIndex = 0; charIndex < currentString.Length + 1; charIndex++)
        {
            Console.Write(" ");
        }
        for (int charIndex = 0; charIndex < currentString.Length + 1; charIndex++)
        {
            Console.Write("\b");
        }
    }

    public void Run()
    {
        // Displays the Welcome Message and Description. Waits for Enter press to continue.
        Console.WriteLine($"{GetWelcomeMessage()} \n{GetDesc()}");
        Console.Write("Press Enter to continue. ");
        Console.ReadLine();

        Console.Clear();

        // Preparation stage
        PrepStage();

        Console.Clear();
        // Draw gauge. Each side has 10 characters to represent the max guage. E.g. < Inhale > || |----------  Hold  ----------| / ||
        // >---------- Exhale ----------< || |  Hold  | /
        // The forward slash in hold represents the throbber.

        string progressLeft = "          <";
        string progressRight = ">          ";
        string gaugeTemplate = $"{progressLeft} Inhale {progressRight}";

        // grabs _inhaleDuration and converts it to miliseconds by multiplying it by 100. This is equal to a seconds to miliseconds converter and dividing by 10.
        int sleepTime = _inhaleDuration * 100;
        Console.Write(gaugeTemplate);

        for (int rep = 0; rep < _reps; rep++)
        {
            // Makes an array out of the template progressLeft and progressRight strings
            char[] progressLeftArray = progressLeft.ToCharArray();
            char[] progressRightArray = progressRight.ToCharArray();
            
            for (int section = 0; section < 10; section++)
            {
                Thread.Sleep(sleepTime);

                // Clear line
                ClearConsoleLine(gaugeTemplate);

                // Expands arrows to the left and right of the gauge.
                progressLeftArray[10 - section] = '-';
                progressLeftArray[10 - (section + 1)] = '<';
                progressRightArray[section] = '-';
                progressRightArray[section + 1] = '>';
                string newLeft = "";
                string newRight = "";
                for (int charIndex = 0; charIndex < progressLeft.Length; charIndex++)
                {
                    newLeft += progressLeftArray[charIndex];
                    newRight += progressRightArray[charIndex];
                }
                Console.Write($"{newLeft} Inhale {newRight}");
            }

            // Inhale Hold process
            Hold("|----------  Hold  ----------| ", _inhaleHoldDuration, gaugeTemplate);

            // Exhale process
            sleepTime = _exhaleDuration * 100;
            for (int section = 0; section < 10; section++)
            {
                Thread.Sleep(sleepTime);
                ClearConsoleLine(gaugeTemplate);
                progressLeftArray[section] = ' ';
                progressLeftArray[section + 1] = '>';
                progressRightArray[10 - section] = ' ';
                progressRightArray[10 - (section + 1)] = '<';
                string newLeft = "";
                string newRight = "";
                for (int charIndex = 0; charIndex < progressLeft.Length; charIndex++)
                {
                    newLeft += progressLeftArray[charIndex];
                    newRight += progressRightArray[charIndex];
                }
                Console.Write($"{newLeft} Exhale {newRight}");
            }

            Hold("          |  Hold  | ", _exhaleHoldDuration, gaugeTemplate);
        }

        Console.WriteLine();
        _universalThrobber.Run();

        Console.WriteLine(GetFinishingMessage());
        _universalThrobber.Run();
    }
    private void Hold(string holdString, int duration, string gaugeTemplate)
    {
        // For hold quadrant
        ClearConsoleLine(gaugeTemplate);
        Console.Write(holdString);
        _holdThrobber.SetSeconds(duration);
        _holdThrobber.Run();
    }
}