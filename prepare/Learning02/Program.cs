using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Umbrella";
        job1._jobTitle = "Precipitation Engineer";
        job1._startYear = 2007;
        job1._endYear = 2016;

        Job job2 = new Job();
        job2._company = "Black Mesa";
        job2._jobTitle = "Anomaly Containment";
        job2._startYear = 1998;
        job2._endYear = 2007;

        Resume resume1 = new Resume();
        resume1._name = "Gregory";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        resume1.Display();
    }
}

public class Job
{
    public string _company = "";
    public string _jobTitle = "";
    public int _startYear = 0;
    public int _endYear = 0;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}

public class Resume
{
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"--------------{_name}----------------");
        Console.WriteLine("Past experience:");
        _jobs.ForEach(i => i.Display());
    }
}