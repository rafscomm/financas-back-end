using financas.Models.DTO;
using financas.Repository;
using financas.Repository.Interfaces;
using financas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace financas.Services;

public class UsuariosService : IUsuariosService
{
    private IUsuariosRepository _usuariosRepository;

    public UsuariosService(IUsuariosRepository _usuarios)
    {
        _usuariosRepository = _usuarios;
    }

    public async Task<UsuariosDTO> Insert(UsuariosDTO usr)
    {

        var user = await _usuariosRepository.Insert(usr);
        return user;
    }

    public async Task<UsuariosDTO> GetById(int id)
    {
        var usr = await _usuariosRepository.GetById(id);
        return usr;
    }
}