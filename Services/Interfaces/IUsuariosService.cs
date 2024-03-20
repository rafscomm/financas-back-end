using financas.Models.DTO;

namespace financas.Services.Interfaces;

public interface IUsuariosService
{
    public Task<UsuariosDTO> Insert(UsuariosDTO usr);
    public Task<UsuariosDTO> GetById(int id);
    
}