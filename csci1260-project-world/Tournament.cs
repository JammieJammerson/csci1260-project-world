using System;
using System.Collections.Generic;
using System.Linq;

public class Tournament
{
    private readonly string matchName;

    public Tournament(string matchName)
    {
        this.matchName = matchName;
    }
    public string RunTournament(List<Player> players)
    {
        if (players == null || players.Count == 0)
        {
            return "No players provided for the tournament.";
        }

        var grouped = players
            .Where(p => !string.IsNullOrEmpty(p.TeamName))
            .GroupBy(p => p.TeamName)
            .ToDictionary(g => g.Key, g => g.ToList());

        var stragglers = players.Where(p => string.IsNullOrEmpty(p.TeamName)).ToList();

        if (grouped.Count < 2)
        {
            var sbFail = new System.Text.StringBuilder();
            sbFail.AppendLine("Not enough teams to run a tournament. Need at least two teams.");
            if (stragglers.Count > 0)
            {
                sbFail.AppendLine("Stragglers:");
                foreach (var s in stragglers) sbFail.AppendLine($" - {s.Name} ({s.Gamertag})");
            }
            return sbFail.ToString().TrimEnd('\r','\n');
        }
        var teams = grouped.ToDictionary(kvp => kvp.Key, kvp => new Team(kvp.Key, kvp.Value));

        int minSize = teams.Values.Min(t => t.Players.Count);

        foreach (var t in teams.Values)
        {
            var leftovers = t.TruncateTo(minSize);
            if (leftovers.Count > 0) stragglers.AddRange(leftovers);
        }

        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"Running tournament '{matchName}' with {teams.Count} teams, {minSize} players per team.");

        var teamPoints = teams.Keys.ToDictionary(k => k, k => 0);
        var rnd = new Random();

        var teamList = teams.Values.ToList();

        var matchRunner = new Match();
        for (int i = 0; i < teamList.Count; i++)
        {
            for (int j = i + 1; j < teamList.Count; j++)
            {
                var teamA = teamList[i];
                var teamB = teamList[j];
                sb.AppendLine($"\nMatch: {teamA.TeamName} vs {teamB.TeamName}");

                var (pointsA, pointsB, log) = matchRunner.Play(teamA, teamB, rnd);
                teamPoints[teamA.TeamName] += pointsA;
                teamPoints[teamB.TeamName] += pointsB;
                if (!string.IsNullOrEmpty(log)) sb.AppendLine(log);
            }
        }

        sb.AppendLine("\nTournament results:");
        foreach (var kvp in teamPoints.OrderByDescending(k => k.Value))
        {
            sb.AppendLine($" - {kvp.Key}: {kvp.Value} points");
        }

        int maxPoints = teamPoints.Values.Max();
        var winners = teamPoints.Where(kvp => kvp.Value == maxPoints).Select(kvp => kvp.Key).ToList();

        if (winners.Count == 1)
        {
            sb.AppendLine($"\nWinner: {winners[0]} with {maxPoints} points");
        }
        else
        {
            sb.AppendLine($"\nIt's a tie between: {string.Join(", ", winners)} with {maxPoints} points each");
        }

        if (stragglers.Count > 0)
        {
            sb.AppendLine("\nStragglers (not participating or left over):");
            foreach (var s in stragglers) sb.AppendLine($" - {s.Name} ({s.Gamertag}) Team: {(string.IsNullOrEmpty(s.TeamName) ? "<none>" : s.TeamName)}");
        }

        return sb.ToString().TrimEnd('\r','\n');
    }
}
