using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanningPoker.Api.Contracts;
using PlanningPoker.Api.Data;
using PlanningPoker.Api.Models;
using PlanningPoker.Api.Models.Story;

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


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<StoryDto>> PostStory(CreateStoryDto createCountryDto)
    {
        var story = _mapper.Map<Story>(createCountryDto);

        await _storiesRepository.AddAsync(story);

        return Created("", new { Id = story.Id });
    }

    [HttpGet]
    public async Task<ActionResult<StoryDto>> GetEstimable()
    {
        var stories = await _storiesRepository.GetEstimableAsync();
        if (stories is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<StoryDto>(stories));
    }

    [HttpGet]
    public async Task<ActionResult<List<FinishedStoryDto>>> GetFinishedStories()
    {
        return await _storiesRepository.GetFinishedEstimations<FinishedStoryDto>();
    }

    [HttpPost("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> StartEstimation(int id)
    {
        await _storiesRepository.StartEstimationAsync(id);
        return NoContent();
    }

    [HttpPost("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> FinishEstimation(int id)
    {
        await _storiesRepository.FinishEstimationAsync(id);
        return NoContent();
    }
}