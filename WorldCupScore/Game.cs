using System;

public class Game
{
    public string HomeTeam { get; }
    public string AwayTeam { get; }
    public int HomeScore { get; private set; }
    public int AwayScore { get; private set; }
    public DateTime CreationTime { get; }

    public Game(string homeTeam, string awayTeam)
    {
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        HomeScore = 0;
        AwayScore = 0;
        CreationTime = DateTime.UtcNow;
    }

    public void UpdateScore(int homeScore, int awayScore)
    {
        HomeScore = homeScore;
        AwayScore = awayScore;
    }

    public int TotalScore => HomeScore + AwayScore;
    public override string ToString()
    {
        return $"{HomeTeam} {HomeScore} - {AwayTeam} {AwayScore}";
    }
}
