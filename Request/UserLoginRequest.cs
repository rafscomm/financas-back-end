using System.ComponentModel.DataAnnotations;

namespace financas.Request;

public class UserLoginRequest
{   [Required(ErrorMessage = "Email é obrigatório"), EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "Senha é obrigatório")]
    public string Password { get; set; }
}