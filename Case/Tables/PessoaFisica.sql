CREATE TABLE [dbo].[PessoaFisica]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [NomeCompleto] NCHAR(50) NOT NULL, 
    [DataNascimento] DATETIME NOT NULL, 
    [ValorRenda] DECIMAL(18, 2) NOT NULL, 
    [Cpf] CHAR(11) NOT NULL
)
