using financas.Models;
using financas.Models.DTO;
using financas.Repository;
using financas.Repository.Interfaces;
using financas.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace financas.Services;

public class DespesasService: IDespesasService
{
    private  readonly IDespesasRepository _despesasRepository;

    public DespesasService(IDespesasRepository _despesas)
    {
        _despesasRepository = _despesas;
    }
    public async Task<IEnumerable<DespesasDTO>> GetAllAsync()
    {
        var desp = await _despesasRepository.GetAllAsync();
        return desp.Select(desp => desp.toDTO());
    }

    public async Task<DespesasDTO> GetDespesa(int id)
    {
        var desp = await _despesasRepository.GetById(id);
        return desp.toDTO();
    }

    public async Task<DespesasDTO> Insert(DespesasDTO desp)
    {
        if (desp != null)
        {
            var res = await _despesasRepository.Insert(desp.toModel());
            return res.toDTO();
        }

        return null;
    }
}