using GreetingApp;

bool runApp = true;

while(runApp == true)
{
    // Greeting App
    // Prompt user to "Enter a command"
    Console.WriteLine("Enter a command");

    // User input command
    string? enteredCommand = Console.ReadLine();

    if(enteredCommand.Substring(0, 5).Equals("greet"))
    {
        Greet greet = new Greet();
        Console.WriteLine("> " + greet.GreetUser(enteredCommand));
    }
    else if(enteredCommand == "exit")
    {
        runApp = false;
    }
    else
    {
        Console.WriteLine("Invalid command");
    }
}


