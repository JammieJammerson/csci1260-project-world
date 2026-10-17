using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string teamName;
    private List<Player> players;

    public Team(string teamName, IEnumerable<Player> players)
    {
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
}
