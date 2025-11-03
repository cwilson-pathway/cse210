using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating new jobs to test Job.cs
        Job job1 = new Job();
        job1._company = "Walmart";
        job1._jobTitle = "Personal Shopper";
        job1._startYear = "2020";
        job1._endYear = "2022";

        // job1.DisplayJob();

        Job job2 = new Job();
        job2._company = "Internal Revenue Service";
        job2._jobTitle = "Tax Examining Technician";
        job2._startYear = "2022";
        job2._endYear = "2025";

        // job2.DisplayJob();

        // Creating new resume object to test inter-class compatibility.
        Resume resume1 = new Resume();
        resume1._personName = "Christian";
        resume1._jobsList.Add(job1);
        resume1._jobsList.Add(job2);

        resume1.DisplayResume();

        
    }
}