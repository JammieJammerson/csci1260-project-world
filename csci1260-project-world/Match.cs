using System;

public class Match : Team
{
    private string team1;

    private string team2;
    public Match(string team1, string team2) : base(team1, new Player[0])
    {
        this.team1 = team1;
        this.team2 = team2;
    }

    public void CheckRank(Player player1, Player player2)
    {
        if (player1.Rank == player2.Rank)
        {
            // Handle same rank case, run the match as normal
        }
        else if (player1.Rank != player2.Rank)
        {
            // Handle having different ranks case       
        }
    }

    public void CheckGame(Player player1, Player player2)
    {
        if (player1.Game == player2.Game)
        {
            // Handle same game case, run the match as normal
        }
        else if (player1.Game != player2.Game)
        {
            // Handle different game case
        }
    }

    public bool CheckPlayStatus(Player player1, Player player2)
    {
        // both must be "active" to return true
        return player1.PlayStatus == player2.PlayStatus;
    }

    public void StartMatch(Player player1, Player player2)
    {
        if (CheckPlayStatus(player1, player2))
        {
            //
        }
        else
        {
            Console.WriteLine("These players are not in the same category. Match cannot be run.");
        }
    }
}
