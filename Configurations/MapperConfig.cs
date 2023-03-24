using AutoMapper;
using PlanningPoker.Api.Data;
using PlanningPoker.Api.Models;

namespace PlanningPoker.Api.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Story, StoryDto>().ReverseMap();
        CreateMap<CreateStoryDto, Story>();
        CreateMap<Vote, VoteDto>().ReverseMap();
    }
}