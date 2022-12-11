using c_sherp_project_api.lib;
using c_sherp_project_api.Models;

namespace unit_testing;

public class UnitTestGameLogic
{
    [Fact]
    public void Draw()
    {
        Result rock = Lib.GetRoundResult(Choice.Rock, Choice.Rock);
        Assert.Equal(Result.Draw, rock);

        Result paper = Lib.GetRoundResult(Choice.Paper, Choice.Paper);
        Assert.Equal(Result.Draw, paper);

        Result scissors = Lib.GetRoundResult(Choice.Scissors, Choice.Scissors);
        Assert.Equal(Result.Draw, scissors);
    }

    [Fact]
    public void Win()
    {
        Result rs = Lib.GetRoundResult(Choice.Rock, Choice.Scissors);
        Assert.Equal(Result.Win, rs);

        Result pr = Lib.GetRoundResult(Choice.Paper, Choice.Rock);
        Assert.Equal(Result.Win, pr);

        Result sp = Lib.GetRoundResult(Choice.Scissors, Choice.Paper);
        Assert.Equal(Result.Win, sp);
    }

    [Fact]
    public void Loss()
    {
        Result rp = Lib.GetRoundResult(Choice.Rock, Choice.Paper);
        Assert.Equal(Result.Loss, rp);

        Result ps = Lib.GetRoundResult(Choice.Paper, Choice.Scissors);
        Assert.Equal(Result.Loss, ps);

        Result sr = Lib.GetRoundResult(Choice.Scissors, Choice.Rock);
        Assert.Equal(Result.Loss, sr);
    }
}