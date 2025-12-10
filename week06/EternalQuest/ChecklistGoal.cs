class ChecklistGoal : Goal
{
    // Creates ChecklistGoal object
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int bonus, int target, int amountCompleted = 0) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        // Similar to SimpleGoal, except uses two integers for its logic instead of checking a boolean.
        int accruedPoints = 0;
        if (_amountCompleted >= _target)
        {
            Console.WriteLine("This goal has already been completed. Please make another one!");
        }
        else
        {
            _amountCompleted++;
            accruedPoints = int.Parse(_points);

            // Gives a one-time bonus defined by the user.
            if (_amountCompleted >= _target)
            {
                Console.WriteLine($"Congratulations on completing this Checklist Goal! You have earned an additional {_bonus} points!");
                accruedPoints += _bonus;
            }
        }

        return accruedPoints;
    }

    public override bool IsComplete()
    {
        bool isComplete = false; // C# REALLY doesn't like it when I don't initialize a bool like this.

        if (_amountCompleted >= _target)
        {
            isComplete = true;
        }

        return isComplete;
    }

    public override string GetDetailsString()
    {
        return base.GetDetailsString() + $" -- Currently Completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation() // Goes into .csv file.
    {
        return $"ChecklistGoal,{base.GetStringRepresentation()},{_bonus},{_target},{_amountCompleted}"; // Format: ChecklistGoal,c,c,50,200,2,2
    }
}