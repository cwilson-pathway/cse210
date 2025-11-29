using System.Dynamic;

class Activity {
    // Parent class of all activities
    // Declare member variables
    private string _activityName;
    private string _activityDesc;
    private int _activityDurSecs;
    private static int _pauseTime = 3;
    protected Throbber _universalThrobber = new Throbber(_pauseTime);

    // Constructor
    public Activity(string name, string desc, int durSecs)
    {
        _activityName = name;
        _activityDesc = desc;
        _activityDurSecs = durSecs;
    }

    // Getters
    public string GetWelcomeMessage()
    {
        return $"Welcome to the {_activityName}!";
    }

    public string GetFinishingMessage()
    {
        return "Well done! Returning to the menu...";
    }

    public string GetDesc()
    {
        return _activityDesc;
    }

    public DateTime GetFutureTime()
    {
        return DateTime.Now.AddSeconds(_activityDurSecs);
    }

    public void PrepStage()
    {
        Console.WriteLine("Get Ready...");
        _universalThrobber.EnableNewLine();
        _universalThrobber.Run();
    }

}