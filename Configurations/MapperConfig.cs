using AutoMapper;
using PlanningPoker.Api.Data;
using PlanningPoker.Api.Models;
using PlanningPoker.Api.Models.Story;
using PlanningPoker.Api.Models.Users;
using PlanningPoker.Api.Models.Vote;

namespace PlanningPoker.Api.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Story, StoryDto>().ReverseMap();
        CreateMap<CreateStoryDto, Story>();
        CreateMap<Vote, VoteDto>().ReverseMap();
        CreateMap<Story, FinishedStoryDto>()
            .ForMember(x => x.VoteValue, opt => opt.MapFrom(src => CalculateVoteValue(src)));

        CreateMap<ApiUserDto, ApiUser>().ReverseMap();
    }

    private static double CalculateVoteValue(Story src)
    {
        if (src.Votes.Count == 0)
        {
            return 0;
        }

        return src.Votes.Average(x => Convert.ToDouble(x.Value));
    }
}