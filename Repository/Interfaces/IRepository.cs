using System.Linq.Expressions;
using financas.Models.DTO;
using financas.Request;
using Microsoft.OpenApi.Any;

namespace financas.Repository.Interfaces;


public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T>? GetById(int id);
    Task<T> Insert(T entity);
    Task<IEnumerable<T>> GetAllPaginate(FilterRequest filter, Expression<Func<T,object>> pred);
}