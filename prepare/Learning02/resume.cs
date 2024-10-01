public class Resume
{
    public string name;

    public List<Job> _jobs;

    public void Display()
    {
        Console.WriteLine($"Name: {name}\n");
        Console.WriteLine("Jobs:");

        foreach (Job j in _jobs)
        {
            j.Display();
        }


        
    }

}