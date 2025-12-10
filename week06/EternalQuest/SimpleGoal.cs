class SimpleGoal : Goal
{
    // Builds SimpleGoal object
    private bool _isComplete = false;

    public SimpleGoal(string name, string description, string points, bool isComplete = false) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent() // Int instead of void because the documentation says that RecordEvent must return an int...
    {
        // Accrues points if not completed. Doesn't if it is completed.
        int accruedPoints = 0;
        if (_isComplete == true)
        {
            Console.WriteLine("This goal has already been completed. Please make another one!");
        }
        else
        {
            _isComplete = true;
            accruedPoints = int.Parse(_points);
        }
        return accruedPoints;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation() // Goes into .csv file.
    {
        return $"SimpleGoal,{base.GetStringRepresentation()},{_isComplete}"; // Format: SimpleGoal,s,s,50,True
    }
}