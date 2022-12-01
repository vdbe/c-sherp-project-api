using c_sherp_project_api.Models;

namespace c_sherp_project_api.Repositories;

public class MockRepo : IRepo {
    int gameIdCounter = 0;
    List<Game> gameList = new List<Game>();

    int leaderBoardIdCounter = 0;
    List<LeaderBoard> leaderBoardList = new List<LeaderBoard>();

    public MockRepo() {
        this.gameList.Add(new Game(){GameId=this.gameIdCounter++, Score=0});
        this.gameList.Add(new Game(){GameId=this.gameIdCounter++, Score=1});
        this.gameList.Add(new Game(){GameId=this.gameIdCounter++, Score=2});
        this.gameList.Add(new Game(){GameId=this.gameIdCounter++, Score=2, Active=false});

        {
            Game game = new Game(){GameId=this.gameIdCounter++, Score=3, Active=false};
            LeaderBoard leaderBoard = new LeaderBoard(){LeaderBoardId=this.leaderBoardIdCounter++, Game=game, GameId=game.GameId};
        }
        {
            Game game = new Game(){GameId=this.gameIdCounter++, Score=2, Active=false};
            LeaderBoard leaderBoard = new LeaderBoard(){LeaderBoardId=this.leaderBoardIdCounter++, Game=game, GameId=game.GameId};
        }
        
    }

    public Task<Game> NewGame()
    {
        Game game = new Game(){GameId=this.gameIdCounter++, Score=1};
        this.gameList.Add(game);

        return Task.FromResult<Game>(game);
    }

    public Task<LeaderBoard> AddGameToLeaderBoard(Guid guid, string name)
    {
        Game game = this.gameList.First(game => game.Guid == guid);
        if (game == null) {
            return null;
        }

        LeaderBoard leaderBoard = new LeaderBoard() {LeaderBoardId=this.leaderBoardIdCounter++, GameId=game.GameId, Game = game};
        this.leaderBoardList.Add(leaderBoard);
        
        return Task.FromResult<LeaderBoard>(leaderBoard);
    }

    public Task<Game> EndGame(Guid guid)
    {
        Game game = this.gameList.First(game => game.Guid == guid);
        if (game == null) {
            return null;
        }

        game.Active = false;

        return Task.FromResult<Game>(game);
    }

    public Task<Game> GetGameByGuid(Guid guid)
    {
        Game game = this.gameList.First(game => game.Guid == guid);
        if (game == null) {
            return null;
        }

        return Task.FromResult<Game>(game);
    }

    public Task<Game> IncrementGameScore(Guid guid)
    {
        Game game = this.gameList.First(game => game.Guid == guid);
        if (game == null) {
            return null;
        }

        if (game.Active == false) {
            // TODO: Error handling
            return null;
        }

        game.Score++;

        return Task.FromResult<Game>(game);
    }

    public Task<int> SaveChanges()
    {
        return Task.FromResult<int>(0);
    }

    public Task<LeaderBoard> GetLeaderBoardByGame(Game game)
    {
        LeaderBoard leaderBoard = this.leaderBoardList.First(lb => lb.GameId == game.GameId);
        if (leaderBoard == null) {
            // TODO: Error handling
            return null;
        }
        
        return Task.FromResult<LeaderBoard>(leaderBoard);
    }
}