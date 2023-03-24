using PlanningPoker.Api.Data;
using PlanningPoker.Api.Models;

namespace PlanningPoker.Api.Contracts;

public interface IStoriesRepository : IGenericRepository<Story>
{
    Task<List<Story>> GetAllNotEstimated();
    Task<List<TResult>> GetAllNotEstimated<TResult>() where TResult : IBaseDto;
    Task<Story?> GetEstimableAsync();
    Task<TResult?> GetEstimableAsync<TResult>() where TResult : IBaseDto;
    Task StartEstimationAsync(int id);
    Task FinishEstimationAsync(int id);
}