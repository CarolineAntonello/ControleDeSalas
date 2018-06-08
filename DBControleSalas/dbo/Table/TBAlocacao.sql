CREATE TABLE [dbo].[TBAlocacao]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DataReserva] DATE NOT NULL, 
    [HoraReservaInicio] DATETIME NOT NULL, 
	[HoraReservaFim] DATETIME NOT NULL,
    [Funcionario_Id] INT NOT NULL, 
    [Sala_Id] INT NOT NULL, 
    CONSTRAINT [FK_TBAlocacao_TBFuncionario] FOREIGN KEY (Funcionario_Id) REFERENCES TBFuncionario(Id) ON DELETE CASCADE, 
    CONSTRAINT [FK_TBAlocacao_TBSerie] FOREIGN KEY (Sala_Id) REFERENCES TBSala(Id) ON DELETE CASCADE
	)
