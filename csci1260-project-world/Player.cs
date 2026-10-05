using System;

public class Player
{
    private int score;

    private string rank;

    private string name;

    private string gamertag;

    public Player(string name, string gamertag)
    {
        this.name = name;
        this.gamertag = gamertag;
        this.score = 0;
        this.rank = "";
    }
}
