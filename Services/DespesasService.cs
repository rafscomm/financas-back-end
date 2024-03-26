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
    private readonly IUnitOfWork _unit;

    public DespesasService(IUnitOfWork _unitOf)
    {
        _unit = _unitOf ;
    }
    public async Task<IEnumerable<DespesasDTO>> GetAllAsync()
    {
        var desp = await _unit.DespesasRepository.GetAllAsync();
        return desp.Select(desp => desp.toDTO());
    }

    public async Task<DespesasDTO> GetDespesa(int id)
    {
        var desp = await _unit.DespesasRepository.GetById(id);
        return desp.toDTO();
    }

    public async Task<DespesasDTO> Insert(DespesasDTO desp)
    {
            var res = await _unit.DespesasRepository.Insert(desp.toModel());
            await _unit.Commit();
            return res.toDTO();
    }
}