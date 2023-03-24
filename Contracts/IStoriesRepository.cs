using PlanningPoker.Api.Data;
using PlanningPoker.Api.Models;

namespace PlanningPoker.Api.Contracts;

public interface IStoriesRepository : IGenericRepository<Story>
{
    public Task<List<Story>> GetAllNotEstimated();
    public Task<List<TResult>> GetAllNotEstimated<TResult>() where TResult : IBaseDto;
    public Task<Story?> GetEstimableAsync();
    public Task<TResult?> GetEstimableAsync<TResult>() where TResult : IBaseDto;
    public Task StartEstimationAsync(int id);
    public Task FinishEstimationAsync(int id);
}