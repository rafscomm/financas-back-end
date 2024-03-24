using financas.Models.DTO;
using financas.Repository.Interfaces;
using financas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace financas.Repository;

public class UsuariosRepository : IUsuariosRepository
{
    private FnDbContext _context;

    public UsuariosRepository(FnDbContext context)
    {
        _context = context;
    }

    public async Task<UsuariosDTO> Insert(UsuariosDTO usr)
    {

        var user = usr.toModel();
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.toDto();
    }

    public async Task<UsuariosDTO> GetById(int id)
    {
        var usr = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == id);
        
        return usr.toDto();
    }
}