using CaseCrud.Domain.Entities;
using CaseCrud.Domain.Interfaces;
using CaseCRUD.Infra.Base;
using Microsoft.EntityFrameworkCore;

namespace CaseCRUD.Repositories
{
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        private readonly CaseCrudDbContext _dbContext;

        public PessoaFisicaRepository(CaseCrudDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<PessoaFisica>> GetPessoasFisicasAsync()
        {
            try
            {
                return await _dbContext.PessoaFisica.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<PessoaFisica>(); 
            }
        }

        public async Task<PessoaFisica> GetPessoaFisicaByIdAsync(int id)
        {
            try
            {
                return await _dbContext.PessoaFisica.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PessoaFisica> GetPessoaFisicaByCpfAsync(string cpf)
        {
            try
            {
                PessoaFisica? pessoaFisica = await _dbContext
                                    .Set<PessoaFisica>()
                                    .FirstOrDefaultAsync(p => p.CPF == cpf);
                return pessoaFisica;
            }
            catch (Exception ex)
            {
                return new PessoaFisica();
            }
        }

        public async Task<int> AddPessoaFisicaAsync(PessoaFisica pessoa)
        {
            try
            {
                _dbContext.PessoaFisica.Add(pessoa);
                await _dbContext.SaveChangesAsync();
                return pessoa.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<bool> UpdatePessoaFisicaAsync(PessoaFisica pessoa)
        {
            try
            {
                _dbContext.Entry(pessoa).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeletePessoaFisicaAsync(int id)
        {
            try
            {
                var pessoa = await _dbContext.Set<PessoaFisica>().FindAsync(id);
                if (pessoa != null)
                {
                    _dbContext.Set<PessoaFisica>().Remove(pessoa);
                   return await _dbContext.SaveChangesAsync() > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
