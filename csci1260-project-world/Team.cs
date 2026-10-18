using System;
using System.Collections.Generic;
using System.Linq;

public class Team : GameEntity
{
    private string teamName;
    private List<Player> players;

    public Team(string teamName, IEnumerable<Player> players)
    {
        if (string.IsNullOrWhiteSpace(teamName)) throw new ArgumentException("Team name required", nameof(teamName));

        this.teamName = teamName;
        this.players = players?.ToList() ?? new List<Player>();

        foreach (var p in this.players)
        {
            if (p != null)
            {
                p.TeamName = teamName;
            }
        }
    }

    public string TeamName { get { return teamName; } }

    public List<Player> Players { get { return players; } }

    protected override string Summary()
    {
        return $"Team: {teamName} ({players.Count} players)";
    }

    protected override string DescribeDetails()
    {
        var sb = new System.Text.StringBuilder();
        foreach (var p in players)
        {
            sb.AppendLine($"  - {p.Name} ({p.Gamertag}) Score: {p.Score}");
        }
        return sb.ToString().TrimEnd('\n','\r');
    }

    public List<Player> TruncateTo(int size)
    {
        if (size <= 0)
        {
            var all = new List<Player>(players);
            players.Clear();
            return all;
        }

        if (players.Count <= size) return new List<Player>();

        var leftovers = players.Skip(size).ToList();
        players = players.Take(size).ToList();
        return leftovers;
    }

    public void AddPlayer(Player p)
    {
        if (p != null)
        {
            p.TeamName = teamName;
            players.Add(p);
        }
    }

    public override string Describe()
    {
        return base.Describe();
    }
}
