using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Activity{
    protected List <List<string>> _promptList;
    protected string _welcomeDescription;
    protected int _duration;

    protected string _name;

    public Activity(){

    }



public void DogAnimation(double durationInSeconds){

    // Set the duration (in seconds) for the dog to cross the screen // Adjust as needed
        int consoleWidth = Console.WindowWidth;
        int dogWidth = 14; // Approximate width of the dog ASCII art
        int position = 0;

        // Calculate total number of steps based on console width and dog width
        int totalSteps = consoleWidth - dogWidth;
        if (totalSteps <= 0) totalSteps = 1; // Avoid division by zero or negative steps

        // Calculate delay based on duration and number of steps
        int delay = (int)((durationInSeconds * 1000) / totalSteps);

        // Flipped frames of the dog in different walking positions
        string[] dogFrames = new string[]
        {
            @"
    Run, Spot, Run!
           __       
    |____{(''o      
    (      ``      
     \-/-/-\
    ",
            @"
    Run, Spot, Run!!
           __       
    \____{(''o      
    (      ``     
     /-\-\-/
    ",
            @"
    Run, Spot, Run!!!
           __       
    |____{(''o      
    (      ``      
     \-/-/-\
    ",
            @"
    Run, Spot, Run!!
           __       
    /____{(''o      
    (      ``      
     /-\-\-/
    "
        };

        // Loop to animate the dog walking across the console
        bool T = true;

        while (T)
        {
            for (int frame = 0; frame < dogFrames.Length; frame++)
            {
                Console.Clear();
                
                // Calculate spaces to move the dog across the screen
                string spaces = new string(' ', position);

                // Print the current frame with spaces
                string[] lines = dogFrames[frame].Split('\n');
                Console.WriteLine(lines[1]);

                for (int i = 2; i < lines.Length; i++)
                {   
                    Console.WriteLine(spaces + lines[i]);
                }

                Thread.Sleep(delay); // Pause dynamically based on duration

                // Update position
                position++;
                if (position > consoleWidth - 2*dogWidth)
                {
                    T=false;
                }
            }
        }

    Console.Clear();

}

public void PromptForDuration()
{
    Console.WriteLine("How many seconds would you like the activity to last?");
    while (true) // Loop until a valid integer is entered
    {
        string input = Console.ReadLine();
        if (int.TryParse(input, out int duration) && duration >= 0) // Checks if input is a valid integer and non-negative
        {
            _duration = duration;
            break;
        }
        else
        {
            Console.WriteLine("Please enter a valid number of seconds.");
        }
    }
}

public string RandomListSelector(List<string> prompt)
{
    Random random = new Random();
    int randomIndex = random.Next(prompt.Count);
    string randomPrompt = prompt[randomIndex];
    
    return(randomPrompt);
}

public void DisplayClosingMessage(){
    Console.Write($"Well Done! You have completed {_duration} seconds of the {_name} activity.");
}

public void Countdown(int seconds){
    Console.CursorVisible = false;
    for(int i=seconds; i>0; i--){
        Console.Write(i);
        Thread.Sleep(1000);
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
    }
    Console.CursorVisible = true;
}

}