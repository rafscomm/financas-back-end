using financas.Models.DTO;
using financas.Repository.Interfaces;
using financas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace financas.Repository;

public class PessoasRepository: IPessoasRepository
{
    private FnDbContext _fnDbContext;

    public PessoasRepository(FnDbContext _fnDbContext)
    {
        this._fnDbContext = _fnDbContext;
    }

    public async Task<IEnumerable<PessoasDTO>> GetAllAsync()
    {
        var pes = await _fnDbContext.Pessoas.ToListAsync();

        return pes.Select(p => p.toDto());
    }

    public async Task<PessoasDTO> Insert(PessoasDTO pesd)
    {
        var pes = pesd.toModel();
        pes.CreatedAt = DateTime.Now;
        await _fnDbContext.AddAsync(pes);
        await _fnDbContext.SaveChangesAsync();

        return pes.toDto();
    }

    public async Task<PessoasDTO> GetById(int id)
    {
        var pes = await _fnDbContext.Pessoas.SingleOrDefaultAsync(p => p.Id == id);
        return pes.toDto();
    }
}