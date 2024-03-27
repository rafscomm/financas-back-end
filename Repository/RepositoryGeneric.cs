using System.Linq.Expressions;
using financas.Repository.Interfaces;
using financas.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace financas.Repository;

public class Repository<T>: IRepository<T> where T : class
{
    protected FnDbContext _fnDbContext;

    public Repository(FnDbContext _context)
    {
        _fnDbContext = _context;
    }   
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var result = await _fnDbContext.Set<T>().AsNoTracking().ToListAsync();
        return result;
    }

    public async Task<T> GetById(int id)
    {
        var result = await _fnDbContext.Set<T>().FindAsync(id);
        return result;
    }

    public async Task<T> Insert(T entity)
    {
        await _fnDbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<T>> GetAllPaginate(FilterRequest filter, Expression<Func<T,object>> pred)
    {
        var result = await _fnDbContext.Set<T>().OrderBy(pred).Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize).ToListAsync();
        return result;
    }
}