using System;
using System.Collections.Generic;

public class Scheduler
{
    private List<Round> rounds = new List<Round>();

    public void BuildRounds(int count, List<Team> teams)
    {
        rounds.Clear();
        for (int i = 0; i < count; i++)
        {
            var r = new Round(i + 1);
            r.GenerateMatches(teams);
            rounds.Add(r);
        }
    }

    public string RunAll()
    {
        var sb = new System.Text.StringBuilder();
        foreach (var r in rounds)
        {
            sb.AppendLine(r.Run());
        }
        return sb.ToString().TrimEnd('\r','\n');
    }
}
