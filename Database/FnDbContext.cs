
using financas.Models;
using Microsoft.EntityFrameworkCore;

public class FnDbContext : DbContext
{
    public DbSet<Pessoas> Pessoas { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Faturamento> Faturamento { get; set; }
    public DbSet<Despesas> Despesas { get; set; }
    
    public FnDbContext (DbContextOptions<FnDbContext> options): base(options)
    {
        
    } 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}