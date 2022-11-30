using System.ComponentModel.DataAnnotations;

namespace c_sherp_project_api.dto;

public class LeaderBoardReadDto
{
    public string Name { get; set; }

    public DateTime on { get; set; }

    public GameReadDto Game { get; set; }
}

public class LeaderBoardWriteDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public Guid Game { get; set; }
}