using System;
using System.Collections.Generic;
using System.Linq;

public class ScoreBoard
{
    private readonly List<Game> _games = new List<Game>();

    public void StartGame(string homeTeam, string awayTeam)
    {
        var game = new Game(homeTeam, awayTeam);
        _games.Add(game);
    }

    public void FinishGame(string homeTeam, string awayTeam)
    {
        var game = _games.FirstOrDefault(g => g.HomeTeam == homeTeam && g.AwayTeam == awayTeam);
        if (game != null)
        {
            _games.Remove(game);
        }
    }

    public void UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore)
    {
        var game = _games.FirstOrDefault(g => g.HomeTeam == homeTeam && g.AwayTeam == awayTeam);
        if (game != null)
        {
            game.UpdateScore(homeScore, awayScore);
        }
    }

    public List<Game> GetSummary()
    {
        return _games.OrderByDescending(g => g.TotalScore)
                     .ThenByDescending(g => g.CreationTime)
                     .ToList();
    }
}
