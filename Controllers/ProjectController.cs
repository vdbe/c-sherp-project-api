using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using c_sherp_project_api.Models;
using c_sherp_project_api.Repositories;
using c_sherp_project_api.dto;
using System.Text.Json;

namespace c_sherp_project_api.Controllers;

[ApiController]
[Route("rps")]
public class RpsController : ControllerBase
{
    private readonly IRepo repo;
    private readonly IMapper map;

    private readonly Random Random = new Random();

    public RpsController(IRepo repo, IMapper map)
    {
        this.repo = repo;
        this.map = map;
    }

    [HttpPost("game")]
    public async Task<ActionResult> IncrementScore()
    {

        Game game = await this.repo.NewGame();

        return Ok(this.map.Map<GameReadDto>(game));
    }

    [HttpGet("game/{guid}")]
    public async Task<ActionResult> GetGame(Guid guid)
    {
        Game game = await this.repo.GetGameByGuid(guid);

        return Ok(this.map.Map<GameReadDto>(game));
    }

    [HttpPost("game/{guid}/play")]
    public async Task<ActionResult> PlayGame(Guid guid, Play play)
    {
        Game game = await this.repo.GetGameByGuid(guid);

        // You can only play active games
        if (game.Active == false)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }

        // Generate random `Choices`
        Array choices = Enum.GetValues(typeof(Choice));
        Choice randomChoice = (Choice)choices.GetValue(this.Random.Next(choices.Length));

        // Check game result
        // 0: draw
        // 1: won
        // 2: lost
        Result result = (Result)((play.Choice - randomChoice + 3) % 3);

        switch (result)
        {
            case Result.Draw:
                {
                    break;
                }
            case Result.Win:
                {
                    game.Score++;
                    break;
                }
            case Result.Loss:
                {
                    game.Active = false;
                    break;
                }
            default:
                {
                    // Unreachable
                    break;
                }
        }

        if (result != Result.Draw)
        {
            await this.repo.SaveChanges();
        }

        PlayReadDto playReadDto = new PlayReadDto() { Game = this.map.Map<GameReadDto>(game), Choice = randomChoice, Result = result };

        return Ok(playReadDto);
    }

    [HttpPost("leaderboard")]
    public async Task<ActionResult> RegisterToLeaderBoard(LeaderBoardWriteDto leaderBoardWriteDto)
    {
        Game game = await this.repo.GetGameByGuid(leaderBoardWriteDto.Game);
        System.Console.WriteLine(JsonSerializer.Serialize(game));

        // Check if game is lost
        // You can only play active games
        if (game.Active == true)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }

        // Check if game is not already registerd
        LeaderBoard leaderBoard = await this.repo.GetLeaderBoardByGame(game);
        System.Console.WriteLine(JsonSerializer.Serialize(leaderBoard));
        if (leaderBoard != null)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }

        await this.repo.AddGameToLeaderBoard(game.Guid, leaderBoardWriteDto.Name);
        await this.repo.SaveChanges();
        LeaderBoard leaderBoard2 = await this.repo.GetLeaderBoardByGame(game);

        LeaderBoardReadDto leaderBoardReadDto = new LeaderBoardReadDto() { Name = leaderBoard2.Name, On = leaderBoard2.On, Game = this.map.Map<GameReadDto>(leaderBoard2.Game) };

        System.Console.WriteLine(JsonSerializer.Serialize(leaderBoard2));

        // Add game to leaderboard
        // TODO: Map to read object
        return Ok(leaderBoardReadDto);
    }
}