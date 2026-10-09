using System;
using System.Diagnostics;
using System.Xml.Linq;

public class Score : IDescribe
{
	private string playerName;

	private string teamName;

	private int score;

	public Score(string playerName, string teamName, int score)
    {
        this.playerName = playerName;
        this.teamName = teamName;
        this.score = score;
    }

    public string Name { get { return playerName; } }
    public string Team { get { return teamName; } }

    public void Win()
    {
        score++;
    }

    public void Lose()
    {
        score--;
    }

    public void Describe()
    {
        Console.WriteLine($"Player: {playerName}, Team: {teamName}, Score: {score}");
    }
}
