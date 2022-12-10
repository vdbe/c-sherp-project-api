using c_sherp_project_api.Models;

namespace c_sherp_project_api.Repositories;

public interface IRepo {
    public Task<LeaderBoard> AddGameToLeaderBoard(Guid guid, String name);

    public Task<Game> IncrementGameScore(Guid guid);

    public Task<Game> NewGame();

    public Task<Game> EndGame(Guid guid);

    public Task<Game> GetGameByGuid(Guid guid);

    public Task<int> SaveChanges();

    public Task<LeaderBoard> GetLeaderBoardByGame(Game game);

    public Task<List<LeaderBoard>> GetLeaderBoard(int count);

}