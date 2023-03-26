using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PlanningPoker.Api.Contracts;
using PlanningPoker.Api.Data;
using PlanningPoker.Api.Models;

namespace PlanningPoker.Api.Repository;

public class StoriesRepository : GenericRepository<Story>, IStoriesRepository
{
    private readonly PlanningPokerDbContext _context;
    private readonly IMapper _mapper;

    public StoriesRepository(PlanningPokerDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TResult>> GetAllNotEstimated<TResult>() where TResult : IBaseDto
    {
        return await _context.Stories.Where(x => !x.IsEstimated && !x.InProgress)
            .ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<List<Story>> GetAllNotEstimated()
    {
        return await _context.Stories.Where(x => !x.IsEstimated && !x.InProgress).ToListAsync();
    }

    public async Task<Story?> GetEstimableAsync()
    {
        return await _context.Stories.FirstOrDefaultAsync(x => x.InProgress);
    }

    public async Task<TResult?> GetEstimableAsync<TResult>() where TResult : IBaseDto
    {
        return _mapper.Map<TResult>(await _context.Stories.FirstOrDefaultAsync(x => x.InProgress));
    }

    public async Task StartEstimationAsync(int id)
    {
        var estimable = await GetEstimableAsync();
        if (estimable != null)
        {
            await FinishEstimationAsync(estimable.Id);
        }

        var story = await GetAsync(id);
        story.InProgress = true;
        await UpdateAsync(story);
    }


    public async Task FinishEstimationAsync(int id)
    {
        var story = await GetAsync(id);
        story.InProgress = false;
        story.IsEstimated = true;
        await UpdateAsync(story);
    }

    public async Task<List<TResult>> GetFinishedEstimations<TResult>() where TResult : IBaseDto
    {
        return _mapper.Map<List<TResult>>(await _context.Stories.Where(x => x.IsEstimated && !x.InProgress).Include(x=>x.Votes)
            .ToListAsync());
    }
}