using System.Runtime.CompilerServices;
using financas.Models;
using financas.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace financas.Repository;

public class DespesasRepository : Repository<Despesas>,IDespesasRepository
{
    public DespesasRepository(FnDbContext dbContext) : base(dbContext)
    {
        _fnDbContext = dbContext;
    }
    /*public  async Task<IEnumerable<DespesasDTO>> GetAllAsync()
    {
        var desp = await _fnDbContext.Despesas.ToListAsync();
            
        return desp.Select(d => d.toDTO());
    }

    public async Task<DespesasDTO> Insert(DespesasDTO desp)
    {
        Despesas despe = desp.toModel();
        
        despe.CreatedAt = DateTime.Now;
        Usuarios usr = await _fnDbContext.Usuarios.SingleOrDefaultAsync(u => u.Id == desp.UsuarioId.Value);
        if (usr != null)
        {
            despe.Usuario = usr;
        }
        await _fnDbContext.AddAsync(despe);
        await _fnDbContext.SaveChangesAsync();

        return despe.toDTO();
    }

    public async Task<DespesasDTO> GetDespesa(int id)
    {
        var desp = await _fnDbContext.Despesas.SingleOrDefaultAsync(d=>d.Id == id);
        
        return desp.toDTO();
    }*/
}