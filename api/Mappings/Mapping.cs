using c_sherp_project_api.dto;
using c_sherp_project_api.Models;

using AutoMapper;
namespace c_sherp_project_api.Mappings;

public class ProjectProfile : Profile {
    public ProjectProfile(){
        CreateMap<Game, GameReadDto>();
        CreateMap<LeaderBoard, LeaderBoardReadDto>();
    }
}