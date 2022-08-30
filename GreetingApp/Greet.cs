namespace GreetingApp;

public class Greet
{
    public string Name {get; set;} = string.Empty;
    public string Language {get; set;} = string.Empty;
    public string GreetPhrase {get; set;} = "Hello";

    Dictionary<string, string> langPhrase = new Dictionary<string, string>()
    {
        {"english", "Hello"},
        {"sepedi", "Dumela"},
        {"isixhosa", "Molo"}
    };

    public string GreetUser(string greetCommand)
    {
        string[] command = greetCommand.ToUpper().Split(" ");
        if(command.Length == 3)
        {
            Name = command[1];
            Language = command[2];
        }

        GreetPhrase = langPhrase[Language.ToLower()];

        return $"{GreetPhrase} {Name[0]}{Name.Substring(1).ToLower()}";
    }
}