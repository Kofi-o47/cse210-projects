public class Resume
{
    // store user variables 
    public string _personName = "";  
    public List<Job> _jobs = new List<Job>();  

    // Method to display the resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_personName}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();  
        }
    }
}

    