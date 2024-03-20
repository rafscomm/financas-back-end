using financas.Models.DTO;
using financas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace financas.Services;

public class UsuariosService : IUsuariosService
{
    private FnDbContext _context;

    public UsuariosService(FnDbContext context)
    {
        this._context = context;
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