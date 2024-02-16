using CaseCrud.Domain.Entities;
using CaseCrud.Domain.Interfaces;


namespace CaseCRUD.Application.Services
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;

        public PessoaFisicaService(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }

        public async Task<IEnumerable<PessoaFisica>> GetPessoasFisicas()
        {
            return await _pessoaFisicaRepository.GetPessoasFisicasAsync();
        }

        public async Task<PessoaFisica> GetPessoaFisicaByCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                throw new ArgumentException("O CPF não pode ser nulo ou vazio.", nameof(cpf));
            }

            return await _pessoaFisicaRepository.GetPessoaFisicaByCpfAsync(cpf);
        }

        public async Task<PessoaFisica> GetPessoaFisicaById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");
            }

            return await _pessoaFisicaRepository.GetPessoaFisicaByIdAsync(id);
        }

        public async Task<int> AddPessoaFisica(PessoaFisica pessoa)
        {

            if (pessoa == null)
                throw new ArgumentNullException(nameof(pessoa), "A pessoa não pode ser nula.");

            if (string.IsNullOrWhiteSpace(pessoa.NomeCompleto))
                throw new ArgumentException("O nome completo não pode ser nulo ou vazio.", nameof(pessoa.NomeCompleto));

            if (pessoa.DataNascimento == default(DateTime))
                throw new ArgumentException("A data de nascimento é obrigatória.", nameof(pessoa.DataNascimento));

            if (pessoa.ValorRenda < 0)
                throw new ArgumentException("O valor da renda deve ser maior ou igual a zero.", nameof(pessoa.ValorRenda));

            if (string.IsNullOrWhiteSpace(pessoa.CPF))
                throw new ArgumentException("O CPF não pode ser nulo ou vazio.", nameof(pessoa.CPF));


            return await _pessoaFisicaRepository.AddPessoaFisicaAsync(pessoa);
        }

        public async Task<bool> UpdatePessoaFisica(PessoaFisica pessoa)
        {
            if (pessoa == null)
            {
                throw new ArgumentNullException(nameof(pessoa), "A pessoa não pode ser nula.");
            }

            return await _pessoaFisicaRepository.UpdatePessoaFisicaAsync(pessoa);
        }

        public async Task<bool> DeletePessoaFisica(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");
            }

            return await _pessoaFisicaRepository.DeletePessoaFisicaAsync(id);
        }

    }
}