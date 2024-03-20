using financas.Models.DTO;

namespace financas.Services.Interfaces;

public interface IPessoasService
{
    public Task<IEnumerable<PessoasDTO>> GetAllAsync();
    public Task<PessoasDTO> Insert(PessoasDTO pesd);
    public Task<PessoasDTO> GetById(int id);
}