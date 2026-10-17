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
    public void RunTournament(List<Player> players)
    {
        if (players == null || players.Count == 0)
        {
            Console.WriteLine("No players provided for the tournament.");
            return;
        }

        var grouped = players
            .Where(p => !string.IsNullOrEmpty(p.TeamName))
            .GroupBy(p => p.TeamName)
            .ToDictionary(g => g.Key, g => g.ToList());

        var stragglers = players.Where(p => string.IsNullOrEmpty(p.TeamName)).ToList();

        if (grouped.Count < 2)
        {
            Console.WriteLine("Not enough teams to run a tournament. Need at least two teams.");
            if (stragglers.Count > 0)
            {
                Console.WriteLine("Stragglers:");
                foreach (var s in stragglers) Console.WriteLine($" - {s.Name} ({s.Gamertag})");
            }
            return;
        }
        var teams = grouped.ToDictionary(kvp => kvp.Key, kvp => new Team(kvp.Key, kvp.Value));

        int minSize = teams.Values.Min(t => t.Players.Count);

        foreach (var t in teams.Values)
        {
            var leftovers = t.TruncateTo(minSize);
            if (leftovers.Count > 0) stragglers.AddRange(leftovers);
        }

        Console.WriteLine($"Running tournament '{matchName}' with {teams.Count} teams, {minSize} players per team.");

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
                Console.WriteLine($"\nMatch: {teamA.TeamName} vs {teamB.TeamName}");

                var (pointsA, pointsB) = matchRunner.Play(teamA, teamB, rnd);
                teamPoints[teamA.TeamName] += pointsA;
                teamPoints[teamB.TeamName] += pointsB;
            }
        }

        Console.WriteLine("\nTournament results:");
        foreach (var kvp in teamPoints.OrderByDescending(k => k.Value))
        {
            Console.WriteLine($" - {kvp.Key}: {kvp.Value} points");
        }

        int maxPoints = teamPoints.Values.Max();
        var winners = teamPoints.Where(kvp => kvp.Value == maxPoints).Select(kvp => kvp.Key).ToList();

        if (winners.Count == 1)
        {
            Console.WriteLine($"\nWinner: {winners[0]} with {maxPoints} points");
        }
        else
        {
            Console.WriteLine($"\nIt's a tie between: {string.Join(", ", winners)} with {maxPoints} points each");
        }

        if (stragglers.Count > 0)
        {
            Console.WriteLine("\nStragglers (not participating or left over):");
            foreach (var s in stragglers) Console.WriteLine($" - {s.Name} ({s.Gamertag}) Team: {(string.IsNullOrEmpty(s.TeamName) ? "<none>" : s.TeamName)}");
        }
    }
}
