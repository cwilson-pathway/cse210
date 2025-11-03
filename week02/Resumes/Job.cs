using System;

public class Job()
{
    // Declaring member variables
    public string _company = "";
    public string _jobTitle = "";
    public string _startYear = "";
    public string _endYear = "";

    // Concatenating public strings for output in Program.Main()
    public void DisplayJob()
    {
        string jobString = $"{_jobTitle} ({_company}) {_startYear}-{_endYear}";
        Console.WriteLine(jobString);
    }
}