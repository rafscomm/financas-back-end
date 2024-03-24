using System.Linq.Expressions;
using financas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        var result = await _fnDbContext.Set<T>().ToListAsync();
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
        await _fnDbContext.SaveChangesAsync();
        return entity;
    }
}