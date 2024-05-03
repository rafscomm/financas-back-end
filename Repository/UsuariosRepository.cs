using financas.Models.DTO;
using financas.Repository.Interfaces;
using financas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace financas.Repository;

public class UsuariosRepository : Repository<Usuarios>,IUsuariosRepository
{

    public UsuariosRepository(FnDbContext _context) : base (_context)
    {
        this._fnDbContext = _context;
    }


    public async Task<Usuarios> GetByEmail(string email)
    {
        return await _fnDbContext.Usuarios.FirstAsync(x => x.Email == email);
    }

    public async Task UpdateToken(Usuarios user)
    {
        var usr = await _fnDbContext.Usuarios.FirstOrDefaultAsync(u => u.Email == user.Email);
        usr.RefreshToken = user.RefreshToken;
        usr.RefreshTokenTime = user.RefreshTokenTime;
        _fnDbContext.Entry(usr).State = EntityState.Modified;
        await _fnDbContext.SaveChangesAsync();
    }
}