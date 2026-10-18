using System;
using System.Collections.Generic;

public class PlayerManager
{
    private List<Player> players = new List<Player>();

    public void Add(Player p)
    {
        if (p == null) throw new ArgumentNullException(nameof(p));
        players.Add(p);
    }

    public IReadOnlyList<Player> Players => players.AsReadOnly();

    public string DescribeAll()
    {
        var sb = new System.Text.StringBuilder();
        foreach (var p in players)
        {
            sb.AppendLine(p.Describe());
        }
        return sb.ToString().TrimEnd('\r','\n');
    }
}
