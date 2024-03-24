using financas.Models.DTO;
using financas.Repository.Interfaces;
using financas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace financas.Repository;

public class PessoasRepository: Repository<Pessoas>,IPessoasRepository
{

    public PessoasRepository(FnDbContext _fnDbContext) : base(_fnDbContext)
    {
        this._fnDbContext = base._fnDbContext;
    }
     
}