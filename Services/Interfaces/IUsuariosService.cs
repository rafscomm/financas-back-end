using financas.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace financas.Services.Interfaces;

public interface IUsuariosService
{
    public Task<UsuariosDTO> Insert(UsuariosDTO usr);
    public Task<UsuariosDTO> GetById(int id);
    public Task<UsuariosDTO> GetByEmail(string email);
    public Task<Usuarios> GetByEmailForAuthorize(string email);
    public Task<PasswordVerificationResult> ValidatePassword(string pass, string email);
    public Task UpdateToken(Usuarios usr);
    public string HashPass(string pass);

}