using Microsoft.EntityFrameworkCore;
using PlanningPoker.Api.Contracts;
using PlanningPoker.Api.Data;

namespace PlanningPoker.Api.Repository;

public class StoriesRepository : GenericRepository<Story>, IStoriesRepository
{
    private readonly PlanningPokerDbContext _context;

    public StoriesRepository(PlanningPokerDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Story>> GetAllNotEstimated()
    {
       return await _context.Stories.Where(x => !x.IsEstimated && !x.InProgress).ToListAsync();
    }

    public async Task<Story?> GetEstimableAsync()
    {
        return await _context.Stories.FirstOrDefaultAsync(x => x.InProgress);
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
}