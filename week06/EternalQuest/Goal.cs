class Goal
{
    // Parent class of goals. names, descriptions, and points will be inherited from this.
    private string _shortName;
    private string _description;
    protected string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public virtual int RecordEvent() // Empty function to be overridden
    {
        return 0;
    }

    public virtual bool IsComplete() // Empty function to be overridden
    {
        return false;
    }

    public virtual string GetDetailsString() // Default behavior for SimpleGoal and EternalGoal, will be overridden in ChecklistGoal.
    {
        string returnString = "";
        
        if (IsComplete() == true)
        {
            returnString = $"[X] {_shortName} ({_description})";
        }
        else
        {
            returnString = $"[ ] {_shortName} ({_description})";
        }

        return returnString;
    }

    public virtual string GetStringRepresentation() // Default is used as the base of each representation, with all other goals adding on top of it.
    {
        return $"{_shortName},{_description},{_points}";
    }
}