using financas.Models.DTO;
using financas.Repository.Interfaces;
using financas.Services.Interfaces;



namespace financas.Services;

public class UsuariosService : IUsuariosService
{
    private  readonly IUnitOfWork _unit;

    public UsuariosService(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<UsuariosDTO> Insert(UsuariosDTO usr)
    {

        var user = await _unit.UsuariosRepository.Insert(usr.toModel());
        await _unit.Commit();
        return user.toDto();
    }

    public async Task<UsuariosDTO> GetById(int id)
    {
        var usr = await _unit.UsuariosRepository.GetById(id);
        return usr.toDto();
    }
}