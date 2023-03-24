using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanningPoker.Api.Contracts;
using PlanningPoker.Api.Data;
using PlanningPoker.Api.Models;

namespace PlanningPoker.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class StoriesController : ControllerBase
{
    private readonly IStoriesRepository _storiesRepository;
    private readonly IMapper _mapper;

    public StoriesController(IStoriesRepository storiesRepository, IMapper mapper)
    {
        _storiesRepository = storiesRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StoryDto>>> GetAllNotEstimated()
    {
        return await _storiesRepository.GetAllNotEstimated<StoryDto>();
    }

    [HttpGet]
    public async Task<ActionResult<StoryDto>> GetEstimable()
    {
        var stories = await _storiesRepository.GetEstimableAsync();
        if (stories is null)
        {
            return NoContent();
        }

        return Ok(_mapper.Map<StoryDto>(stories));
    }
}