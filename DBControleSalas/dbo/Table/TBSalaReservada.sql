CREATE TABLE [dbo].[TBSalaReservada]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DataReserva] DATE NOT NULL, 
    [HoraReserva] DATETIME NOT NULL, 
    [Funcionario_Id] INT NOT NULL, 
    [Sala_Id] INT NOT NULL, 
    CONSTRAINT [FK_TBSalaReservada_TBFuncionario] FOREIGN KEY (Funcionario_Id) REFERENCES TBFuncionario(Id) ON DELETE CASCADE, 
    CONSTRAINT [FK_TBSalaReservada_TBSala] FOREIGN KEY (Sala_Id) REFERENCES TBSala(Id) ON DELETE CASCADE 
)
