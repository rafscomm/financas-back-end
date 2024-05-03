using System.Linq.Expressions;
using financas.Repository.Interfaces;
using financas.Request;
using financas.Response;
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

    public async Task<T> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public  async Task<IQueryable<T>> GetAllPaginate(Expression<Func<T,object>> pred)
    {
        var result =  _fnDbContext.Set<T>().OrderBy(pred);
        await result.ToListAsync();
        return result;
    }
}