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

        GreetPhrase = langPhrase[Language.ToLower()];
        AddNameToDic(Name);

        return $"{GreetPhrase} {Name[0]}{Name.Substring(1).ToLower()}";
    }

    // Add a name to list
    public void AddNameToDic(string greetedName)
    {
        if(greetedNames.ContainsKey(greetedName))
        {
            greetedNames[greetedName] += 1; 
        }
        else
        {
            greetedNames.Add(greetedName, 1);
        }
    }

    // Return list of greeted names
    public Dictionary<string, int> GetDic()
    {
        return greetedNames;
    }

}