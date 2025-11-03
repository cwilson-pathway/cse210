using System;

public class Resume()
{
    // Declaring member variables
    public string _personName = "";
    public List<Job> _jobsList = new List<Job>();

    // Displaying Resume
    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_personName}" +
        "\nJobs:");
        foreach (Job item in _jobsList)
        {
            item.DisplayJob();
        }
    }
}