namespace GreetingApp;

public class Greet
{
    public string Name {get; set;} = string.Empty;
    public string Language {get; set;} = string.Empty;
    public string GreetPhrase {get; set;} = "Hello";
    
    Dictionary<string, int> greetedNames;

    public Greet()
    {
        greetedNames = new Dictionary<string, int>();
    }

    // Greet user with specified language
    public string GreetUser(string greetCommand)
    {
        Dictionary<string, string> langPhrase = new Dictionary<string, string>()
        {
            {"english", "Hello"},
            {"sepedi", "Dumela"},
            {"isixhosa", "Molo"}
        };

        string[] command = greetCommand.ToUpper().Split(" ");

        if(command.Length == 3)
        {
            Name = command[1];
            Language = command[2];
        }

        Name = Name[0] + Name.Substring(1).ToLower();
        GreetPhrase = langPhrase[Language.ToLower()];

        // Adding name to dictionary
        if(greetedNames.ContainsKey(Name))
        {
            greetedNames[Name] += 1; 
        }
        else
        {
            greetedNames.Add(Name, 1);
        }

        return $"{GreetPhrase} {Name}";
    }

    // List of greeted names
    public Dictionary<string, int> Greeted()
    {
        return greetedNames;
    }

    // return how many times a users has been greeted
    public string GreetedTimes(string greetCommand, Dictionary<string, int> dictOfNames)
    {
        string[] command = greetCommand.ToUpper().Split(" ");
        
        if(command.Length == 2 && command[0] == "greeted")
        {
            Name = command[1];
        }

        //Name = Name[0] + Name.Substring(1).ToLower();

        string res = $"{Name}: {dictOfNames[Name]}";

        return Name;
    }
}