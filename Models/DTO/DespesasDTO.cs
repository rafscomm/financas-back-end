using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace financas.Models.DTO;

public class DespesasDTO
{
    public int? Id { get; set; }
    public TipoDespesas Tipo { get; set; } = 0;
    [Required]
    public string Descricao { get; set; }
    [Required]
    public DateTime Competencia { get; set; }
    public DateTime? DataPagamento { get; set; }
    public StatusPagamento Status { get; set; } = 0;
    [Required]
    public decimal Valor { get; set; }
    
    public int? PessoaId { get; set; }
    public int? UsuarioId { get; set; }
    
}

public static class DespesaExtendsDTO
{
    public static DespesasDTO toDTO(this Despesas desp)
    {
        DespesasDTO despDto = new DespesasDTO();

        despDto.Id = desp.Id;
        despDto.Competencia = desp.Competencia;
        despDto.Descricao = desp.Descricao;
        despDto.DataPagamento = desp.DataPagamento;
        despDto.UsuarioId = desp.UsuarioId;
        despDto.Status = desp.Status;
        despDto.Tipo = desp.Tipo;
        despDto.Valor = desp.Valor;
        despDto.PessoaId = desp.PessoaId;

        return despDto;
    }

    public static Despesas toModel(this DespesasDTO despDto)
    {
        Despesas desp = new Despesas();

        desp.Descricao = despDto.Descricao;
        desp.Competencia = despDto.Competencia;
        desp.DataPagamento = despDto.DataPagamento;
        desp.Status = despDto.Status;
        desp.Tipo = despDto.Tipo;
        desp.Valor = despDto.Valor;

        return desp;
    }
}