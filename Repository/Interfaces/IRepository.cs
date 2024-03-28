using System.Linq.Expressions;
using financas.Request;
using financas.Response;
using Microsoft.OpenApi.Any;

namespace financas.Repository.Interfaces;


public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T>? GetById(int id);
    Task<T> Insert(T entity);
    Task<IQueryable<T>> GetAllPaginate(Expression<Func<T,object>> pred);
}