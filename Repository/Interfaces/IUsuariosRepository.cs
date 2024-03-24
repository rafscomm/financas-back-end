using financas.Models.DTO;

namespace financas.Repository.Interfaces;

public interface IUsuariosRepository
{
    public Task<UsuariosDTO> Insert(UsuariosDTO usr);
    public Task<UsuariosDTO> GetById(int id);
    
}