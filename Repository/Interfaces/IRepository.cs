using System.Linq.Expressions;
using financas.Models.DTO;

namespace financas.Repository.Interfaces;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T>? GetById(int id);
    Task<T> Insert(T entity);
}