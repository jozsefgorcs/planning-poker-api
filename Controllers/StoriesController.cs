using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanningPoker.Api.Data;
using PlanningPoker.Api.Models;

namespace PlanningPoker.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StoriesController : ControllerBase
{
    private readonly PlanningPokerDbContext _dbContext;
    private readonly IMapper _mapper;

    public StoriesController(PlanningPokerDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<StoryDto> Get()
    {
        //test
        var stories = _dbContext.Stories.Include(q=>q.Votes);
        return _mapper.Map<List<StoryDto>>(stories);

    }
}
