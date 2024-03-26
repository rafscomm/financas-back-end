using financas.Models.DTO;
using financas.Repository.Interfaces;
using financas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace financas.Services;

public class PessoasService: IPessoasService
{
    private  readonly IUnitOfWork _unit;

    public PessoasService(IUnitOfWork unit)
    {
        _unit = unit;
    }


    public async Task<IEnumerable<PessoasDTO>> GetAllAsync()
    {
        var pes = await _unit.PessoasRepository.GetAllAsync();
        return pes.Select(p => p.toDto());
    }

    public async Task<PessoasDTO> Insert(PessoasDTO pesd)
    {
        var pes = await _unit.PessoasRepository.Insert(pesd.toModel());
        await _unit.Commit();
        return pes.toDto();
    }

    public async Task<PessoasDTO> GetById(int id)
    {
        var pes = await _unit.PessoasRepository.GetById(id);
        return pes.toDto();
    }
}