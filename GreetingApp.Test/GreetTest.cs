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


        // Then
        Assert.Equal(greetedNames, greet.Greeted("greeted"));
    }
}