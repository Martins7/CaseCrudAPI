using CaseCrud.Domain.Entities;
using CaseCrud.Domain.Interfaces;
using CaseCRUD.Application.Services;
using Moq;
using Xunit;

namespace CaseCRUD.Tests
{
    public class PessoaFisicaServiceTests
    {
        [Fact]
        public async Task GetPessoasFisicas_ShouldReturnPessoas()
        {
            var mockRepository = new Mock<IPessoaFisicaRepository>();
            mockRepository.Setup(repo => repo.GetPessoasFisicasAsync())
                          .ReturnsAsync(new List<PessoaFisica>
                          {
                          new PessoaFisica { Id = 1, NomeCompleto = "Jhon" },
                          new PessoaFisica { Id = 2, NomeCompleto = "Maria" }
                          });

            var pessoaService = new PessoaFisicaService(mockRepository.Object);

            var pessoas = await pessoaService.GetPessoasFisicas();

            Assert.NotNull(pessoas);
            Assert.Equal(2, pessoas.Count());
        }

        [Fact]
        public async Task GetPessoaFisicaByCpf_ShouldReturnPessoa()
        {

            var cpf = "123.456.789-01";
            var mockRepository = new Mock<IPessoaFisicaRepository>();
            mockRepository.Setup(repo => repo.GetPessoaFisicaByCpfAsync(cpf))
                          .ReturnsAsync(new PessoaFisica { Id = 1, NomeCompleto = "Jhon", CPF = cpf });

            var pessoaService = new PessoaFisicaService(mockRepository.Object);

            var pessoa = await pessoaService.GetPessoaFisicaByCpf(cpf);

            Assert.NotNull(pessoa);
            Assert.Equal(cpf, pessoa.CPF);
        }

        [Fact]
        public async Task GetPessoaFisicaById_ShouldReturnPessoa()
        {

            var id = 1;
            var mockRepository = new Mock<IPessoaFisicaRepository>();
            mockRepository.Setup(repo => repo.GetPessoaFisicaByIdAsync(id))
                          .ReturnsAsync(new PessoaFisica { Id = id, NomeCompleto = "Jhon" });

            var pessoaService = new PessoaFisicaService(mockRepository.Object);

            var pessoa = await pessoaService.GetPessoaFisicaById(id);

            Assert.NotNull(pessoa);
            Assert.Equal(id, pessoa.Id);
        }

        [Fact]
        public async Task AddPessoaFisica_ShouldReturnId()
        {
            var pessoa = new PessoaFisica { 
                NomeCompleto = "Jhon", 
                CPF="1234567890",
                ValorRenda = 500, 
                DataNascimento = DateTime.Now,
            };
            var mockRepository = new Mock<IPessoaFisicaRepository>();
            mockRepository.Setup(repo => repo.AddPessoaFisicaAsync(pessoa))
                          .ReturnsAsync(1);

            var pessoaService = new PessoaFisicaService(mockRepository.Object);

            var id = await pessoaService.AddPessoaFisica(pessoa);

            Assert.Equal(1, id);
        }

        [Fact]
        public async Task UpdatePessoaFisica_ShouldReturnTrue()
        {
            var pessoa = new PessoaFisica { Id = 1, NomeCompleto = "Jhon" };
            var mockRepository = new Mock<IPessoaFisicaRepository>();
            mockRepository.Setup(repo => repo.UpdatePessoaFisicaAsync(pessoa))
                          .ReturnsAsync(true);

            var pessoaService = new PessoaFisicaService(mockRepository.Object);

            var result = await pessoaService.UpdatePessoaFisica(pessoa);

            Assert.True(result);
        }

        [Fact]
        public async Task DeletePessoaFisica_ShouldReturnTrue()
        {
            var id = 1;
            var mockRepository = new Mock<IPessoaFisicaRepository>();
            mockRepository.Setup(repo => repo.DeletePessoaFisicaAsync(id))
                          .ReturnsAsync(true);

            var pessoaService = new PessoaFisicaService(mockRepository.Object);

            var result = await pessoaService.DeletePessoaFisica(id);

            Assert.True(result);
        }
    }
}