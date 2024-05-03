using financas.Models.DTO;

namespace financas.Repository.Interfaces;

public interface IUsuariosRepository : IRepository<Usuarios>
{
    public Task<Usuarios> GetByEmail(string email);
    public Task UpdateToken(Usuarios user);
}