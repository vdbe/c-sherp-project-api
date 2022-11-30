using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace c_sherp_project_api.Models;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }

    public string Urgency { get; set; }

}

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

static class ChoicesMethods {
    /// 0: draw
    /// 1: won
    /// 2: lost
    public static int Compare(this Choice choice1, Choice choice2) {
        // Draw
        if (choice1 == choice2) {
            return 0;
        }

        

        return 0;
    }
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

    public DateTime on { get; set; } = DateTime.UtcNow;

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