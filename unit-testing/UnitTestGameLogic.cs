using c_sherp_project_api.lib;
using c_sherp_project_api.Models;

namespace unit_testing;

public class UnitTestGameLogic
{
    [Theory]
    [InlineData(Choice.Rock, Choice.Rock, Result.Draw)]
    [InlineData(Choice.Paper, Choice.Paper, Result.Draw)]
    [InlineData(Choice.Scissors, Choice.Scissors, Result.Draw)]
    [InlineData(Choice.Rock, Choice.Scissors, Result.Win)]
    [InlineData(Choice.Paper, Choice.Rock, Result.Win)]
    [InlineData(Choice.Scissors, Choice.Paper, Result.Win)]
    [InlineData(Choice.Rock, Choice.Paper, Result.Loss)]
    [InlineData(Choice.Paper, Choice.Scissors, Result.Loss)]
    [InlineData(Choice.Scissors, Choice.Rock, Result.Loss)]
    public void GetRoundResultTest(Choice choice1, Choice choice2, Result result)
    {
        Result r = Lib.GetRoundResult(choice1, choice2);
        Assert.Equal(result, r);
    }

    [Theory]
    [MemberData(nameof(GameData))]
    public void UpdateGameLogicTest(Game startGame, List<Result> results, Game endGame)
    {
        Game game = startGame;

        foreach (Result result in results)
        {
            Lib.UpdateGame(ref game, result);
        }

        Assert.Equal(game.Score, endGame.Score);
        Assert.Equal(game.Active, endGame.Active);
    }


    public static IEnumerable<object[]> GameData()
    {
        yield return new object[] { new Game(), new List<Result> { Result.Win }, new Game() { Score = 1, Active = true } };
        yield return new object[] { new Game(), new List<Result> { Result.Loss }, new Game() { Score = 0, Active = false } };
        yield return new object[] { new Game(), new List<Result> { Result.Draw, Result.Win }, new Game() { Score = 1, Active = true } };
        yield return new object[] { new Game(), new List<Result> { Result.Draw, Result.Win, Result.Loss }, new Game() { Score = 1, Active = false } };
        yield return new object[] { new Game(), new List<Result> { Result.Loss, Result.Win }, new Game() { Score = 0, Active = false } };
        yield return new object[] { new Game(), new List<Result> { Result.Win, Result.Loss, Result.Win }, new Game() { Score = 1, Active = false } };
        yield return new object[] { new Game() { Score = 1 }, new List<Result> { Result.Loss }, new Game() { Score = 1, Active = false } };
        yield return new object[] { new Game() { Active = false }, new List<Result> { Result.Win }, new Game() { Score = 0, Active = false } };
    }

}