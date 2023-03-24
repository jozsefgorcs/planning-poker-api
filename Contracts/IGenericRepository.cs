using PlanningPoker.Api.Models;

namespace PlanningPoker.Api.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetAsync(int? id);
    Task<List<T>> GetAllAsync();
    Task<List<TResult>> GetAllAsync<TResult>();
    Task<T> AddAsync(T entity);
    Task<TResult> AddAsync<TSource, TResult>(TSource source);
    Task DeleteAsync(int id);
    Task UpdateAsync(T entity);
    Task UpdateAsync<TSource>(int id, TSource source) where TSource : IBaseDto;
    Task<bool> Exists(int id);
}