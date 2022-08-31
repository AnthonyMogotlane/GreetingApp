using GreetingApp;

// Instance of Greet
Greet greet = new Greet();

bool runApp = true;

while(runApp == true)
{
    // Greeting App
    // Prompt user to "Enter a command"
    Console.WriteLine("Enter a command");

    // User input command
    string? enteredCommand = Console.ReadLine();

    if(enteredCommand == "exit")
    {
        runApp = false;
    }
    else if(enteredCommand.Substring(0, 5).Equals("greet") && enteredCommand.Split(" ").Length == 3)
    {
        Console.WriteLine("> " + greet.GreetUser(enteredCommand));
    }
    else if(enteredCommand == "greeted")
    {
        foreach (var nameCount in greet.Greeted())
        {
            Console.WriteLine( $"{nameCount.Key}: {nameCount.Value}");  
        }
    }
    else if(enteredCommand.Split(" ")[0] == "greeted" && enteredCommand.Split(" ").Length == 2)
    {
        Console.WriteLine("> " + greet.GreetedTimes(enteredCommand, greet.Greeted()));
    }
    else
    {
        Console.WriteLine("Invalid command");
    }
}


