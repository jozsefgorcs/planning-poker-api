using AutoMapper;
using PlanningPoker.Api.Data;
using PlanningPoker.Api.Models;

namespace PlanningPoker.Api.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Story, StoryDto>().ReverseMap();
        CreateMap<Vote, VoteDto>().ReverseMap();
    }
}