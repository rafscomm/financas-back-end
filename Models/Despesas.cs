using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace financas.Models;
public class Despesas: IModelBase
{   [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public TipoDespesas Tipo { get; set; }
    [StringLength(300), Required]
    public string Descricao { get; set; }
    [Required]
    public DateTime Competencia { get; set; }
    public StatusPagamento Status { get; set; }
    public DateTime? DataPagamento { get; set; }
    [Column(TypeName = "decimal(13,2")]
    public decimal Valor { get; set; }
    public int? PessoaId { get; set; }
    public int  UsuarioId { get; set; }
    
    public Pessoas Pessoa { get; set; } = null!;
    public Usuarios Usuario { get; set; } = null!;
}