using System;

class Program
{
    static void Main(string[] args)

    {

        Job job1 = new();
        job1._jobTitle  = "Software Engineer";
        job1._company = "Google";
        job1._startYear = 2018;
        job1._endYear = 2020;

        Job job2 = new();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2020;
        job2._endYear = 2024;

        
        Resume resume = new();
        resume._jobs = [];
        resume.name = "John Smith";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}