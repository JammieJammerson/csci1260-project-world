using System;

public class Spectator : Participant
{
    private string seat;

    public Spectator(string name, string gamertag, int score, string seat = "General") : base(name, gamertag, score)
    {
        this.seat = seat ?? "General";
    }

    protected override string DescribeDetails()
    {
        return $"  Spectator seat: {seat}";
    }

    public override string Describe()
    {
        return base.Describe() + "\n  (Spectator)";
    }
}
