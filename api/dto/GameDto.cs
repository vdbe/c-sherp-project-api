using c_sherp_project_api.Models;

namespace c_sherp_project_api.dto;

public class GameReadDto
{
    public Guid Guid { get; set; }

    public bool Active {get;set;}

    public uint Score { get; set; }
}


public class PlayReadDto  {
    public GameReadDto Game {get;set;}

    public Choice Choice {get;set;}

    public Result Result {get; set;}
}