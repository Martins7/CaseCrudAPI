namespace CaseCrud.Domain.Entities
{
    public class PessoaFisica
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal ValorRenda { get; set; }
        public string CPF { get; set; }
    }
}
