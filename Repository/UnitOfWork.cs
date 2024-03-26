using financas.Repository.Interfaces;

namespace financas.Repository;

public class UnitOfWork : IUnitOfWork
{
    private IDespesasRepository? _despesasRepository;
    private IPessoasRepository? _pessoasRepository;
    private IUsuariosRepository? _usuariosRepository; 
    public FnDbContext _context;

    public UnitOfWork(FnDbContext _contextDb)
    {
        _context = _contextDb;
    }

    public IDespesasRepository DespesasRepository
    {
        get
        {
            return _despesasRepository = _despesasRepository ?? new DespesasRepository(_context);
        }
    }

    public IPessoasRepository PessoasRepository
    {
        get
        {
            return _pessoasRepository = _pessoasRepository ?? new PessoasRepository(_context);
        }
    }

    public IUsuariosRepository UsuariosRepository
    {
        get
        {
            return _usuariosRepository = _usuariosRepository ?? new UsuariosRepository(_context);
        }
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
    
}