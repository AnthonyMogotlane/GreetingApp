using System.Text.Json;
using System.Text.Json.Serialization;

namespace GreetingApp.Test;

public class GreetTest
{
    Greet greet = new Greet();

    [Fact]
    public void ShouldReturnAMessageGreetingTheUserWithSepedi()
    {
        Assert.Equal("Dumela Anthony", greet.GreetUser("greet anthony sepedi"));
    }

    [Fact]
    public void ShouldReturnAMessageGreetingTheUserWithEnglish()
    {
        Assert.Equal("Hello Andre", greet.GreetUser("greet Andre english"));
    }

    [Fact]
    public void ShouldReturnAMessageGreetingTheUserWithIsixhsa()
    {
        Assert.Equal("Molo Makho", greet.GreetUser("greet makho isixhosa"));
    }

    [Fact]
    public void ShouldReturnAListOfAllNamesGreeted()
    {
        // When
        greet.GreetUser("greet john sepedi");
        greet.GreetUser("greet lebo english");
        greet.GreetUser("greet phakamisa isixhosa");

        Dictionary<string, int> greetedNames = new Dictionary<string, int>()
        {
            {"John", 1},
            {"Lebo", 1},
            {"Phakamisa", 1}
        };

        // Then
        Assert.Equal(JsonSerializer.Serialize(greetedNames),  JsonSerializer.Serialize(greet.Greeted()));
    }

    [Fact]
    public void ShouldBeAbleToIncrementTheNumberOfTimesAUserHasBeenGreeted()
    {
        // When
        greet.GreetUser("greet Naledi sepedi");
        greet.GreetUser("greet lebo english");
        greet.GreetUser("greet zeze isixhosa");
        greet.GreetUser("greet zeze isixhosa");

        Dictionary<string, int> greetedNames = new Dictionary<string, int>()
        {
            {"Naledi", 1},
            {"Lebo", 1},
            {"Zeze", 2}
        };

        // Then
        Assert.Equal(JsonSerializer.Serialize(greetedNames),  JsonSerializer.Serialize(greet.Greeted()));
    }

    [Fact]
    public void ShouldReturnTheNameOfTheUserAndHowManyTimesTheyHaveBeenGreeted()
    {
        // When
        greet.GreetUser("greet Naledi sepedi");
        greet.GreetUser("greet Naledi sepedi");
        greet.GreetUser("greet Naledi sepedi");
        greet.GreetUser("greet yonela sepedi");
        greet.GreetUser("greet Naledi sepedi");
        greet.GreetUser("greet yonela sepedi");
        // Then
        Dictionary<string, int> greetedNames = new Dictionary<string, int>()
        {
            {"Naledi", 4},
            {"Yonela", 2}
        };

        Assert.Equal("Yonela: 2", greet.GreetedTimes("greeted yonela", greetedNames));
        Assert.Equal("Naledi: 4", greet.GreetedTimes("greeted naledi", greetedNames));
    }

    [Fact]
    public void ShouldReturnHowManyUniqueUsersHaveBeenGreeted()
    {
        // When
        greet.GreetUser("greet Somizi sepedi");
        greet.GreetUser("greet Rocki sepedi");
        greet.GreetUser("greet john sepedi");
        greet.GreetUser("greet yonela sepedi");
        greet.GreetUser("greet Naledi sepedi");
        greet.GreetUser("greet yonela sepedi");
        // Then
        Dictionary<string, int> greetedNames = new Dictionary<string, int>()
        {
            {"Naledi", 1},
            {"Yonela", 2},
            {"Somizi", 1},
            {"Rocki", 1},
            {"John", 1},
        };

        Assert.Equal(5, greet.Counter(greetedNames));
    }

    [Fact]
    public void ShouldDeleteAllGreetedNamesAndResetCounter()
    {
        // When
        greet.GreetUser("greet Somizi sepedi");
        greet.GreetUser("greet Rocki sepedi");
        greet.GreetUser("greet john sepedi");
        greet.GreetUser("greet yonela sepedi");
        greet.GreetUser("greet Naledi sepedi");
        greet.GreetUser("greet yonela sepedi");
        // Then
        // Dictionary<string, int> greetedNames = new Dictionary<string, int>()
        // {
        //     {"Naledi", 1},
        //     {"Yonela", 2},
        //     {"Somizi", 1},
        //     {"Rocki", 1},
        //     {"John", 1},
        // };

        Assert.Equal(5, greet.Counter(greet.Greeted()));
    }

    [Fact]
    public void ShouldBeAbleToClearTheGreetedNamesFromTheListAndClearTheCount()
    {
        // When
        greet.GreetUser("greet Somizi sepedi");
        greet.GreetUser("greet Rocki sepedi");
        greet.GreetUser("greet john sepedi");
        greet.GreetUser("greet yonela sepedi");
        greet.GreetUser("greet Naledi sepedi");
        greet.GreetUser("greet yonela sepedi");

        //  Dictionary<string, int> greetedNames = new Dictionary<string, int>()
        // {
        //     {"Naledi", 1},
        //     {"Yonela", 2},
        //     {"Somizi", 1},
        //     {"Rocki", 1},
        //     {"John", 1},
        // };

        // Then
        Dictionary<string, int> emptyDic = new Dictionary<string, int>();

        Assert.Equal(emptyDic, greet.Clear(greet.Greeted()));
    }

    [Fact]
    public void ShouldBeAbleToClearANameFromTheGreetedNames()
    {
        // When
        greet.GreetUser("greet Somizi sepedi");
        greet.GreetUser("greet Rocki sepedi");
        greet.GreetUser("greet john sepedi");
        greet.GreetUser("greet yonela sepedi");
        greet.GreetUser("greet Naledi sepedi");
        greet.GreetUser("greet yonela sepedi");

        // Then
        Assert.Equal("Naledi has been removed from the list", greet.ClearName("clear naledi", greet.Greeted()));
        Assert.Equal(4, greet.Counter(greet.Greeted()));

        Dictionary<string, int> greetedNames = new Dictionary<string, int>()
        {
            {"Somizi", 1},
            {"Rocki", 1},
            {"John", 1},
            {"Yonela", 2},
        };

        Assert.Equal(JsonSerializer.Serialize(greetedNames), JsonSerializer.Serialize(greet.Greeted()));
    }

}