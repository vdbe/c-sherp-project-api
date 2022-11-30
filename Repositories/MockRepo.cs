using c_sherp_project_api.Models;

namespace c_sherp_project_api.Repositories;

public class MockRepo : IRepo {
    List<Game> gameList = new List<Game>();
    List<LeaderBoard> leaderBoardList = new List<LeaderBoard>();

    public MockRepo() {
    }

    public Task<LeaderBoard> AddGameToLeaderBoard(Guid guid, string name)
    {
        throw new NotImplementedException();
    }

    public Task<Game> EndGame(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<Game> GetGameByGuid(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<Game> IncrementGameScore(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<Game> NewGame()
    {
        throw new NotImplementedException();
    }

    Task<LeaderBoard> IRepo.AddGameToLeaderBoard(Guid guid, string name)
    {
        throw new NotImplementedException();
    }

    Task<Game> IRepo.EndGame(Guid guid)
    {
        throw new NotImplementedException();
    }

    Task<Game> IRepo.GetGameByGuid(Guid guid)
    {
        throw new NotImplementedException();
    }

    Task<LeaderBoard> IRepo.GetLeaderBoardByGame(Game game)
    {
        throw new NotImplementedException();
    }

    Task<Game> IRepo.IncrementGameScore(Guid guid)
    {
        throw new NotImplementedException();
    }

    Task<Game> IRepo.NewGame()
    {
        throw new NotImplementedException();
    }

    Task<int> IRepo.SaveChanges()
    {
        throw new NotImplementedException();
    }
}