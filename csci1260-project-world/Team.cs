using System;

public class Team : Player
{
    private string teamName;

    private Player[] players;

    public Team(string teamName, Player[] players) : base(players[0].Name, players[0].Gamertag, players[0].Score, players[0].Rank, players[0].Game)
    {
        this.teamName = teamName;
        this.players = players;
    }

    public string TeamName { get { return teamName; } }
    public void CheckTeam(Player player)
    {
        if(player.TeamName is null)
        {
            Console.WriteLine($"{player.Name} is not on a team.");

        }
        else
        {
            Console.WriteLine($"{player.Name} is on the {player.TeamName} team.");
        }
}
