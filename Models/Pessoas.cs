
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Pessoas: IModelBase
{   [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    [StringLength(100), Required]
    public string Nome { get; set; }
    public int? UsuarioId { get; set; }
    public Usuarios Usuario { get; set; } = null!;
}