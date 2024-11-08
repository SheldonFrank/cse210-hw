using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Listing : Activity
{
    private Thread inputThread;
    private CancellationTokenSource cts;
    private bool isTimeUp;
    private string[] _prompts; 

    public Listing()
    {
        _name = "Listing";
        _welcomeDescription = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _prompts = new string[] {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public async Task ListingActivity()
    {
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Length);
        string randomPrompt = _prompts[randomIndex];

        ConsoleSpinner spinner = new ConsoleSpinner();
        Console.Clear();
        PromptForDuration();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"---- {randomPrompt} ----");
        Console.Write("Starting in ");
        Countdown(5);

        TimeSpan duration = TimeSpan.FromSeconds(_duration);
        isTimeUp = false;
        cts = new CancellationTokenSource();

        // Start the input thread
        inputThread = new Thread(() => InputLoop(cts.Token));
        inputThread.Start();

        await Task.Delay(duration);
        isTimeUp = true;
        cts.Cancel();

        // Wait for the input thread to exit
        inputThread.Join();

        Console.Clear();
        Console.WriteLine("Time's up!\n");
        DisplayClosingMessage();
        spinner.Turn(4000);
        Console.Clear();
    }

    private void InputLoop(CancellationToken token)
{
    try
    {
        string input = "";
        while (!token.IsCancellationRequested && !isTimeUp)
        {
            Console.Write("\n> ");
            input = "";
            while (true)
            {
                if (token.IsCancellationRequested || isTimeUp)
                {
                    break;
                }

                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        break;
                    }
                    else if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, input.Length - 1);
                        Console.Write("\b \b");
                    }
                    else if (keyInfo.KeyChar >= 32 && keyInfo.KeyChar <= 126)
                    {
                        input += keyInfo.KeyChar;
                        Console.Write(keyInfo.KeyChar);
                    }
                }
                else
                {
                    Thread.Sleep(50);
                }
            }

            if (!string.IsNullOrEmpty(input))
            {
                
            }
        }
    }
    catch (OperationCanceledException)
    {
        
    }
}

}
