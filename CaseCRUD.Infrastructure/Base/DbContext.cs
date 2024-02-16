
using CaseCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseCRUD.Infra.Base
{
    public class CaseCrudDbContext : DbContext
    {
        public CaseCrudDbContext(DbContextOptions<CaseCrudDbContext> options)
        : base(options)
        {
        }

        public DbSet<PessoaFisica> PessoaFisica { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PessoaFisica>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.NomeCompleto).HasMaxLength(100).IsRequired();
                entity.Property(e => e.DataNascimento).IsRequired();
                entity.Property(e => e.ValorRenda).HasPrecision(18,2).IsRequired();
                entity.Property(e => e.CPF).HasMaxLength(11).IsRequired();
            });
        }

    }
}
