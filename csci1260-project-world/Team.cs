using System;

public class Team
{
    private string teamName;

    private Player[] players;

    public Team(string teamName, Player[] players)
    {
        this.teamName = teamName;
        this.players = players;
    }
}
