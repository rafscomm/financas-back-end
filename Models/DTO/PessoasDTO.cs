using System.ComponentModel.DataAnnotations;

namespace financas.Models.DTO;

public class PessoasDTO
{
    public int? Id { get; set; }
    [Required]
    public string Nome { get; set; }
    public int? usuarioId { get; set; }
}

public static class PessoasExtendDTO
{
    public static PessoasDTO toDto(this Pessoas pes)
    {
        PessoasDTO pesd = new PessoasDTO();

        pesd.Id = pes.Id;
        pesd.Nome = pes.Nome;
        pesd.usuarioId = pes.UsuarioId;

        return pesd;
    }

    public static Pessoas toModel(this PessoasDTO pesd)
    {
        Pessoas pes = new Pessoas();

        pes.Nome = pesd.Nome;

        return pes;
    }
}