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

    [MemberData(nameof(Data))]
    public void VerifyGetCarListAsync(int? colorID, List<int> carIDs, int? sellerID){
        Assert.Equal(carIDs.Count, 3);
    }


    public static IEnumerable<object[]> Data(){
        yield return new object[] { null, new List<int>{ 42, 2112 }, null };
        yield return new object[] { 1, new List<int>{ 43, 2112 }, null };
        yield return new object[] { null, new List<int>{ 44, 2112 }, 6 };
    }

}