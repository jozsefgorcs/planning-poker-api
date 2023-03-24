using PlanningPoker.Api.Data;

namespace PlanningPoker.Api.Contracts;

public interface IStoriesRepository : IGenericRepository<Story>
{
    public Task<List<Story>> GetAllNotEstimated();
    public Task<Story?> GetEstimableAsync();
    public Task StartEstimationAsync(int id);
    public Task FinishEstimationAsync(int id);
}