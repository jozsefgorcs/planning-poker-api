using System.Formats.Asn1;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PlanningPoker.Api.Contracts;
using PlanningPoker.Api.Data;
using PlanningPoker.Api.Exceptions;
using PlanningPoker.Api.Models;

namespace PlanningPoker.Api.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly PlanningPokerDbContext _context;
    private readonly IMapper _mapper;

    public GenericRepository(PlanningPokerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<T> GetAsync(int? id)
    {
        if (id is null)
        {
            return null;
        }

        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    
    public async Task<List<TResult>> GetAllAsync<TResult>()
    {
        return await _context.Set<T>().ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TResult> AddAsync<TSource, TResult>(TSource source)
    {
        var entity = _mapper.Map<T>(source);
            
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<TResult>(entity); 
    }
    
    public async Task DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        if (entity is null)
        {
            throw new NotFoundException(typeof(T).Name, id);
        }

        _context.Set<T>().Remove(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync<TSource>(int id, TSource source) where TSource : IBaseDto
    {
        if (id != source.Id)
        {
            throw new BadRequestException("Invalid Id used in request");
        }

        var entity = await GetAsync(id);

        if(entity == null)
        {
            throw new NotFoundException(typeof(T).Name, id);
        }

        _mapper.Map(source, entity);
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await GetAsync(id);
        return entity != null;
    }
}