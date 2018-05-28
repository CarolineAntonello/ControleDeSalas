CREATE TABLE [dbo].[TBSalaReservada]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DataReserva] DATE NOT NULL, 
    [HoraReserva] TIME NOT NULL, 
    [Funcionario_Id] INT NOT NULL, 
    [Sala_Id] INT NOT NULL, 
    CONSTRAINT [FK_TBSalaReservada_TBFuncionario] FOREIGN KEY (Funcionario_Id) REFERENCES TBFuncionario(Id), 
    CONSTRAINT [FK_TBSalaReservada_TBSala] FOREIGN KEY (Sala_Id) REFERENCES TBSala(Id)
)
