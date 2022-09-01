using GreetingApp;

// Instance of Greet
Greet greet = new Greet();

bool runApp = true;

while(runApp == true)
{
    // Greeting App
    // Prompt user to "Enter a command"
    Console.WriteLine();
    Console.WriteLine("Enter a command");

    // User input command
    string? enteredCommand = Console.ReadLine().ToLower();
    

    if(enteredCommand == "exit")
    {
        runApp = false;
    }
    else if(enteredCommand == "help")
    {
        Console.WriteLine("Greeting app commands:");
        foreach (var command in Commands.Help())
        {
            Console.WriteLine($"  {command}");
        }
    }
    else if(enteredCommand.Split(" ")[0] == "greet" && enteredCommand.Split(" ").Length == 2)
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
    else if(enteredCommand == "counter")
    {
        Console.WriteLine(greet.Counter(greet.Greeted()));
    }
    else if(enteredCommand == "clear")
    {
        greet.Clear(greet.Greeted());
        Console.WriteLine("The names has been cleared...");
    }
    else if(enteredCommand.Split(" ")[0] == "clear" && enteredCommand.Split(" ").Length == 2)
    {
        Console.WriteLine(greet.ClearName(enteredCommand, greet.Greeted()));
    }
    else
    {
        Console.WriteLine("Invalid command");
    }
}


