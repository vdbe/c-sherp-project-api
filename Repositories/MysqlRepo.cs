using c_sherp_project_api.Contexts;
using c_sherp_project_api.Models;

namespace c_sherp_project_api.Repositories;

public class MysqlRepo : IRepo
{
    private readonly ProjectDbContext context;

    public MysqlRepo(ProjectDbContext projectDbContext)
    {
        this.context = projectDbContext;
        
    }
    public async Task<Game> GetGameByGuid(Guid guid)
    {
        Game game = this.context.Games.FirstOrDefault<Game>(game => game.Guid == guid);
        if (game == null) {
            // TODO: Error handling
            return null;
        }

        return game;
    }

    public async Task<Game> NewGame() {
        Game game = new Game();

        await this.context.Games.AddAsync(game);

        await this.SaveChanges();

        return game;
    }

    public async Task<Game> EndGame(Guid guid) {
        Game game = await this.GetGameByGuid(guid);
        if (game == null) {
            return null;
        }

        game.Active = false;

        await this.SaveChanges();

        return game;
    }

    public async Task<Game> IncrementGameScore(Guid guid) {
        Game game = await this.GetGameByGuid(guid);
        if (game == null) {
            return null;
        }

        if (game.Active == false) {
            // TODO: Error handling
            return null;
        }

        game.Score++;

        await this.SaveChanges();

        return game;
    }

    public async Task<LeaderBoard> AddGameToLeaderBoard(Guid guid, String name) {
        Game game = await this.GetGameByGuid(guid);
        if (game == null) {
            return null;
        }

        LeaderBoard leaderBoard = new LeaderBoard() {Game = game};
        await this.context.LeaderBoard.AddAsync(leaderBoard);

        await this.SaveChanges();

        return leaderBoard;
    }
    
    public async Task<LeaderBoard> GetLeaderBoardByGame(Game game)
    {
        LeaderBoard leaderBoard = this.context.LeaderBoard.FirstOrDefault<LeaderBoard>(l => l.GameId == game.GameId);
        if (leaderBoard == null) {
            // TODO: Error handling
            return null;
        }

        return leaderBoard;
    }

    public async Task<int> SaveChanges()
    {
        return await this.context.SaveChangesAsync();
    }
}