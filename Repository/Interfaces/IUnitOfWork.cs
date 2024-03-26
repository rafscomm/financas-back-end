using System.Transactions;

namespace financas.Repository.Interfaces;

public interface IUnitOfWork
{    IDespesasRepository DespesasRepository { get; }
     IPessoasRepository PessoasRepository { get; }
     IUsuariosRepository UsuariosRepository { get; }
     Task Commit();
}