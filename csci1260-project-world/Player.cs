using System;

public class Player : Participant
{
    private string rank;
    private string game;
    private string playStyle;
    private string teamName;

    public Player(string name, string gamertag, int score, string rank, string game, string playStyle, string teamName = null)
        : base(name, gamertag, score)
    {
        if (string.IsNullOrWhiteSpace(rank)) throw new ArgumentException("Rank required", nameof(rank));
        if (string.IsNullOrWhiteSpace(game)) throw new ArgumentException("Game required", nameof(game));

        this.rank = rank;
        this.game = game;
        this.playStyle = playStyle;
        this.teamName = teamName;
    }

    public string Rank { get { return rank; } }
    public string Game { get { return game; } }
    public string PlayStyle { get { return playStyle; } }
    public string TeamName { get { return teamName; } set { teamName = value; } }

    protected override string DescribeDetails()
    {
        var s = $"  Player details: Rank={rank}, Game={game}, Style={playStyle}";
        if (!string.IsNullOrEmpty(teamName)) s += "\n  Team: " + teamName;
        return s;
    }

    public override string Describe()
    {
        return base.Describe();
    }
}
