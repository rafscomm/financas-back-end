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

    
}