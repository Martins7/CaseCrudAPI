using CaseCrud.Domain.Entities;

namespace CaseCrud.Domain.Interfaces
{
    public interface IPessoaFisicaRepository
    {
        Task<IEnumerable<PessoaFisica>> GetPessoasFisicasAsync();
        Task<PessoaFisica> GetPessoaFisicaByCpfAsync(string cpf);
        Task<PessoaFisica> GetPessoaFisicaByIdAsync(int id);
        Task<int> AddPessoaFisicaAsync(PessoaFisica pessoa); 
        Task<bool> UpdatePessoaFisicaAsync(PessoaFisica pessoa);
        Task<bool> DeletePessoaFisicaAsync(int pessoa);
    }
}
