using System;
using System.Collections.Generic;

public class Match
{
    public (int pointsA, int pointsB, string log) Play(Team teamA, Team teamB, Random rnd = null)
    {
        if (teamA == null) throw new ArgumentNullException(nameof(teamA));
        if (teamB == null) throw new ArgumentNullException(nameof(teamB));

        rnd ??= new Random();

        int pointsA = 0;
        int pointsB = 0;
        var sb = new System.Text.StringBuilder();
        int size = Math.Min(teamA.Players.Count, teamB.Players.Count);

        for (int i = 0; i < size; i++)
        {
            var pA = teamA.Players[i];
            var pB = teamB.Players[i];

            if (pA.PlayStatus != "Active" || pB.PlayStatus != "Active")
            {
                sb.AppendLine($"  Skipping match between {pA.Name} and {pB.Name} due to inactivity.");
                continue;
            }

            bool aWins = rnd.Next(2) == 0;
            if (aWins)
            {
                pointsA++;
                sb.AppendLine($"  {pA.Name} (Team {teamA.TeamName}) defeated {pB.Name} (Team {teamB.TeamName})");
            }
            else
            {
                pointsB++;
                sb.AppendLine($"  {pB.Name} (Team {teamB.TeamName}) defeated {pA.Name} (Team {teamA.TeamName})");
            }
        }

        return (pointsA, pointsB, sb.ToString().TrimEnd('\r','\n'));
    }
}
