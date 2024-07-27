using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FootballScoreBoard.Tests
{
    [TestClass]
    public class ScoreBoardTests
    {
        [TestMethod]
        public void TestStartGame()
        {
            var scoreBoard = new ScoreBoard();
            scoreBoard.StartGame("Mexico", "Canada");

            var games = scoreBoard.GetSummary();
            Assert.AreEqual(1, games.Count);
            Assert.AreEqual("Mexico", games[0].HomeTeam);
            Assert.AreEqual("Canada", games[0].AwayTeam);
            Assert.AreEqual(0, games[0].HomeScore);
            Assert.AreEqual(0, games[0].AwayScore);
        }

        [TestMethod]
        public void TestFinishGame()
        {
            var scoreBoard = new ScoreBoard();
            scoreBoard.StartGame("Mexico", "Canada");
            scoreBoard.FinishGame("Mexico", "Canada");

            var games = scoreBoard.GetSummary();
            Assert.AreEqual(0, games.Count);
        }

        [TestMethod]
        public void TestUpdateScore()
        {
            var scoreBoard = new ScoreBoard();
            scoreBoard.StartGame("Mexico", "Canada");
            scoreBoard.UpdateScore("Mexico", "Canada", 2, 1);

            var games = scoreBoard.GetSummary();
            Assert.AreEqual(1, games.Count);
            Assert.AreEqual(2, games[0].HomeScore);
            Assert.AreEqual(1, games[0].AwayScore);
        }

        [TestMethod]
        public void TestGetSummary()
        {
            var scoreBoard = new ScoreBoard();

            scoreBoard.StartGame("Mexico", "Canada");
            scoreBoard.UpdateScore("Mexico", "Canada", 0, 5);
            Thread.Sleep(100);

            scoreBoard.StartGame("Spain", "Brazil");
            scoreBoard.UpdateScore("Spain", "Brazil", 10, 2);
            Thread.Sleep(100);

            scoreBoard.StartGame("Germany", "France");
            scoreBoard.UpdateScore("Germany", "France", 2, 2);
            Thread.Sleep(100);

            scoreBoard.StartGame("Uruguay", "Italy");
            scoreBoard.UpdateScore("Uruguay", "Italy", 6, 6);
            Thread.Sleep(100);

            scoreBoard.StartGame("Argentina", "Australia");
            scoreBoard.UpdateScore("Argentina", "Australia", 3, 1);

            var summary = scoreBoard.GetSummary();

            Assert.AreEqual("Uruguay", summary[0].HomeTeam);
            Assert.AreEqual("Italy", summary[0].AwayTeam);
            Assert.AreEqual(6, summary[0].HomeScore);
            Assert.AreEqual(6, summary[0].AwayScore);
            Assert.AreEqual("Spain", summary[1].HomeTeam);
            Assert.AreEqual("Brazil", summary[1].AwayTeam);
            Assert.AreEqual(10, summary[1].HomeScore);
            Assert.AreEqual(2, summary[1].AwayScore);
            Assert.AreEqual("Mexico", summary[2].HomeTeam);
            Assert.AreEqual("Canada", summary[2].AwayTeam);
            Assert.AreEqual(0, summary[2].HomeScore);
            Assert.AreEqual(5, summary[2].AwayScore);
            Assert.AreEqual("Argentina", summary[3].HomeTeam);
            Assert.AreEqual("Australia", summary[3].AwayTeam);
            Assert.AreEqual(3, summary[3].HomeScore);
            Assert.AreEqual(1, summary[3].AwayScore);
            Assert.AreEqual("Germany", summary[4].HomeTeam);
            Assert.AreEqual("France", summary[4].AwayTeam);
            Assert.AreEqual(2, summary[4].HomeScore);
            Assert.AreEqual(2, summary[4].AwayScore);
        }
    }
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var game = new Game("Uruguay", "Italy");
            game.UpdateScore(3, 2);

            // Act
            var result = game.ToString();

            // Assert
            Assert.AreEqual("Uruguay 3 - Italy 2", result);
        }
    }
}
