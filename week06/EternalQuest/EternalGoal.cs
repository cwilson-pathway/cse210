class EternalGoal : Goal
{
    // Creates EternalGoal object
    public EternalGoal(string name, string description, string points) : base(name, description, points){}

    public override int RecordEvent()
    {
        return int.Parse(_points);
    }

    public override bool IsComplete()
    {
        return base.IsComplete();
    }

    public override string GetStringRepresentation() // Goes into .csv file.
    {
        return $"EternalGoal,{base.GetStringRepresentation()}"; // Format: EternalGoal,e,e,50
    }
}