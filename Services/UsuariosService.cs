using financas.Models.DTO;
using financas.Repository.Interfaces;
using financas.Services.Interfaces;
using financas.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;


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
        usr.Senha = HashPass(usr.Senha);
        var user = await _unit.UsuariosRepository.Insert(usr.toModel());
        await _unit.Commit();
        return user.toDto();
    }

    public async Task<UsuariosDTO> GetById(int id)
    {
        var usr = await _unit.UsuariosRepository.GetById(id);
        return usr.toDto();
    }

    public async Task<UsuariosDTO> GetByEmail(string email)
    {
        var usr = await _unit.UsuariosRepository.GetByEmail(email);
        return usr.toDto();
    }

    public async Task<PasswordVerificationResult> ValidatePassword(string pass, string email)
    {
        var user = await _unit.UsuariosRepository.GetByEmail(email);
        Hash<Usuarios> hash = new Hash<Usuarios>();
        PasswordVerificationResult result = hash.VerifyHashedPassword(new Usuarios(),user.Senha, pass);
        return result;
    }

    public async Task UpdateToken(Usuarios usr)
    {
        await _unit.UsuariosRepository.UpdateToken(usr);
        await _unit.Commit();
    }

    public string HashPass(string pass)
    {
        Hash<Usuarios> hash = new Hash<Usuarios>();
        return hash.HashPassword(new Usuarios(),pass);
    }
    public async Task<Usuarios> GetByEmailForAuthorize(string email)
    {
        var usr = await _unit.UsuariosRepository.GetByEmail(email);
        return usr;
    }
}
