using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace financas.Models.DTO;

public class UsuariosDTO
{
    public int? Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required,MinLength(6)]
    public string Senha { get; set; }
    public DateTime? LastLogin { get; set; }
}

public static class UsuarioExtendsDTO
{
    public static UsuariosDTO toDto(this Usuarios usr)
    {
        UsuariosDTO usrd = new UsuariosDTO();
        usrd.Id = usr.Id;
        usrd.Email = usr.Email;
        usrd.Nome = usr.Nome;
        usrd.Senha = usr.Senha;
        usrd.LastLogin = usr.LastLogin;

        return usrd;
    }

    public static Usuarios toModel(this UsuariosDTO usrd)
    {
        Usuarios usr = new Usuarios();

        usr.Nome = usrd.Nome;
        usr.Email = usrd.Email;
        usr.Senha = usrd.Senha;

        return usr;
    }
}