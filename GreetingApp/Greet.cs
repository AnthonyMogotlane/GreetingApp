namespace GreetingApp;

public class Greet
{
    public string Name {get; set;} = string.Empty;
    public string Language {get; set;} = "english";
    public string GreetPhrase {get; set;} = "Hello";
    public int Count {get; set;}
    
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

        Name = command[1];
        
        if(command.Length == 3)
        {
            Language = command[2] != "" ? command[2] : "english";
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

        Language = "english";
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
        string res = string.Empty;

        Name = command[1];
        Name = Name[0] + Name.Substring(1).ToLower();

        if(dictOfNames.ContainsKey(Name))
        {
            res = $"'{Name}' has been greeted {dictOfNames[Name]} time/s";
        }
        else
        {
            res = $"Sorry '{Name}' hasn't been greeted";
        }

        return res;
    }

    // Counter
    public int Counter(Dictionary<string, int> greetedNames)
    {
        Count = greetedNames.Count();
        return Count;
    }

    // Clear List
    public Dictionary<string, int> Clear(Dictionary<string, int> dic)
    {
        dic.Clear();
        Count = dic.Count();
        return dic;
    }

    // Clear name
    public string ClearName(string clearCommand, Dictionary<string, int> dic)
    {

        string[] command = clearCommand.ToUpper().Split(" ");

        Name = command[1];
        Name = Name[0] + Name.Substring(1).ToLower();

        dic.Remove(Name);

        return $"{Name} has been removed from the list";
    }
    
}