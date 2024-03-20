using System.ComponentModel.DataAnnotations;

public class Usuarios: IModelBase
{   [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Senha { get; set; }
    public DateTime LastLogin { get; set; }
}