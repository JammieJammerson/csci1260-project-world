using System;

public class Player : IDescribe
{
    private int score;

    private string rank;

    private string name;

    private string gamertag;

    private string game;

    private string playStyle;

    public Player(string name, string gamertag, int score, string rank, string game, string playStyle)
    {
        this.name = name;
        this.gamertag = gamertag;
        this.score = score;
        this.rank = rank;
        this.game = game;
        this.playStyle = playStyle;
    }

    public string Name { get { return name; } }
    public string Gamertag { get { return gamertag; } }
    public int Score { get { return score; } }
    public string Rank { get { return rank; } }
    public string Game { get { return game; } }
    public string PlayStyle { get { return playStyle; } }

    public void Describe()
    {
        Console.WriteLine($"Player: {name}, Gamertag: {gamertag}, Score: {score}, Rank: {rank}, Game: {game}");
    }
}
