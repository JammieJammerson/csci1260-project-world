using System;

public class Game : Match
{
    private string title;

    private string genre;

    public Game(string title, string genre) : base("Team A", "Team B")
    {
        this.title = title;
        this.genre = genre;
    }
}
