using financas.Models.DTO;
using financas.Repository.Interfaces;
using financas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace financas.Services;

public class PessoasService: IPessoasService
{
    private IPessoasRepository _pessoasRepository;

    public PessoasService(IPessoasRepository _pessoas)
    {
        _pessoasRepository = _pessoas;
    }

    public async Task<IEnumerable<PessoasDTO>> GetAllAsync()
    {
        var pes = await _pessoasRepository.GetAllAsync();

        return pes;
    }

    public async Task<PessoasDTO> Insert(PessoasDTO pesd)
    {
        var pes = await _pessoasRepository.Insert(pesd);
        return pes;
    }

    public async Task<PessoasDTO> GetById(int id)
    {
        var pes = await _pessoasRepository.GetById(id);
        return pes;
    }
}