CREATE TABLE [dbo].[TBFuncionario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] NCHAR(50) NOT NULL, 
    [Cargo] NCHAR(50) NOT NULL, 
    [Ramal] INT NOT NULL,
)
