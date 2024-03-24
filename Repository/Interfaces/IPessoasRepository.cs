using financas.Models.DTO;

namespace financas.Repository.Interfaces;

public interface IPessoasRepository
{
    public Task<IEnumerable<PessoasDTO>> GetAllAsync();
    public Task<PessoasDTO> Insert(PessoasDTO pesd);
    public Task<PessoasDTO> GetById(int id);
}