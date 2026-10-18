using System;
using System.Collections.Generic;

public class Round
{
    private int number;
    private List<(Team, Team)> matches = new List<(Team, Team)>();

    public Round(int number)
    {
        this.number = number;
    }

    public void GenerateMatches(List<Team> teams)
    {
        matches.Clear();
        if (teams == null) return;
        for (int i = 0; i < teams.Count; i++)
        {
            for (int j = i + 1; j < teams.Count; j++)
            {
                matches.Add((teams[i], teams[j]));
            }
        }
    }

    public string Run()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"Running Round {number} with {matches.Count} matches");
        var m = new Match();
        var rnd = new Random(number);
        foreach (var (a, b) in matches)
        {
            sb.AppendLine($" Match: {a.TeamName} vs {b.TeamName}");
            var (pa, pb, log) = m.Play(a, b, rnd);
            if (!string.IsNullOrEmpty(log)) sb.AppendLine(log);
        }
        return sb.ToString().TrimEnd('\r','\n');
    }
}
