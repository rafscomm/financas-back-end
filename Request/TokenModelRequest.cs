using System.ComponentModel.DataAnnotations;

namespace financas.Request;

public class TokenModelRequest
{
    [Required]
    public string AcessToken { get; set; }
    [Required]
    public string RefreshToken { get; set; }
}