using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace c_sherp_project_api.Models;

public enum Choice
{
    [Description("Rock")]
    Rock = 0,
    [Description("Paper")]
    Paper = 1,
    [Description("Scissors")]
    Scissors = 2,
}

public enum Result
{
    [Description("Draw")]
    Draw = 0,
    [Description("Win")]
    Win = 1,
    [Description("Loss")]
    Loss = 2,
}

public class Play
{
    [Required]
    public Choice Choice { get; set; }
}

public class LeaderBoard
{
    public int LeaderBoardId { get; set; }
    public string Name { get; set; } = "Anonymous";

    public DateTime On { get; set; } = DateTime.UtcNow;

    // Foreign key for `Game`
    public int GameId { get; set; }
    public Game Game { get; set; }

}

public class Game
{
    public int GameId { get; set; }

    public Guid Guid { get; set; } = Guid.NewGuid();

    public bool Active { get; set; } = true;

    public uint Score { get; set; } = 0;

}