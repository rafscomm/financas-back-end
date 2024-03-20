using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Faturamento: IModelBase
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public TipoFaturamento Tipo { get; set; }
    [Column(TypeName = "decimal(13,2")]
    public decimal Valor { get; set; }
    [StringLength(200),Required]
    public string Descricao { get; set; }
    public DateTime Competencia { get; set; }
    public int? PessoaId { get; set; }
    public int UsuarioId { get; set; }
    public Pessoas Pessoa { get; set; } = null!;

    public Usuarios Usuario { get; set; } = null!;
}