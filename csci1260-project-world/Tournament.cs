using System;
using System.Runtime.CompilerServices;

public class Tournament
{
    private string match;

    private string teamName;

    public Tournament(string match, string teamName)
    {
        this.match = match;
        this.teamName = teamName;
    }

    public string Match { get { return match; } }

    public string TeamName { get { return teamName; } }

    public void RunTournament(Player player1, Player player2)
    {
        if (player1.PlayStyle == "SinglePlayer" && player2.PlayStyle == "SinglePlayer")
        {
            Console.WriteLine($"Running tournament for match: {match} with players: {player1.Name}, {player2.Name}");
        }
        else if (player1.PlayStyle == "Multiplayer" && player2.PlayStyle == "Multiplayer")
        {
            Console.WriteLine($"Running tournament for match: {match} with teams: {player1.Name}, {player2.Name}");
        }
        else
        {
            Console.WriteLine("Players have different play styles. Tournament cannot be run.");
        }
    }
}
