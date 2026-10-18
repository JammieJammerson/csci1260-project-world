using System;

public abstract class Participant : GameEntity
{
    private string name;
    private string gamertag;
    private int score;
    private string playStatus = "Active";

    protected Participant(string name, string gamertag, int score)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required", nameof(name));
        if (string.IsNullOrWhiteSpace(gamertag)) throw new ArgumentException("Gamertag required", nameof(gamertag));
        if (score < 0) throw new ArgumentException("Score cannot be negative", nameof(score));

        this.name = name;
        this.gamertag = gamertag;
        this.score = score;
    }

    public string Name { get { return name; } }
    public string Gamertag { get { return gamertag; } }
    public int Score { get { return score; } }
    public string PlayStatus { get { return playStatus; } set { playStatus = value; } }

    protected override string Summary()
    {
        return $"Participant: {name} ({gamertag}) Score: {score}";
    }
    protected abstract override string DescribeDetails();

    public override string Describe()
    {
        return base.Describe() + "\n  Status: " + playStatus;
    }
}
