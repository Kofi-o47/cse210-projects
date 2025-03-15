public class Job
{
    // store user variables 
    public string _jobTitle = "";  
    public string _company = "";  
    public int _startYear;       
    public int _endYear;          

    // Display format 
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}