using CaseCrud.Domain.Entities;

namespace CaseCrud.Domain.Interfaces
{
    public interface IPessoaFisicaService
    {
        Task<IEnumerable<PessoaFisica>> GetPessoasFisicas();
        Task<PessoaFisica> GetPessoaFisicaByCpf(string cpf);
        Task<PessoaFisica> GetPessoaFisicaById(int id);
        Task<int> AddPessoaFisica(PessoaFisica pessoa);
        Task<bool> UpdatePessoaFisica(PessoaFisica pessoa);
        Task<bool> DeletePessoaFisica(int id);
    }
}
