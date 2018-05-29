using ControleDeSalas.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Common.Test.Base
{
    public static class BaseSqlTest
    {
        private const string RECREATE_FUNCIONARIO_TABLE = "DELETE FROM [dbo].[TBFuncionario]" +
                                                   "DBCC CHECKIDENT ('TBFuncionario', RESEED, 0)";

        private const string RECREATE_SALA_TABLE = "DELETE FROM [dbo].[TBSala]" +
                                                       "DBCC CHECKIDENT ('TBSala', RESEED, 0)";

        private const string RECREATE_SALARESERVADA_TABLE = "DELETE FROM [dbo].[TBSalaReservada]" +
                                                       "DBCC CHECKIDENT ('TBSalaReservada', RESEED, 0)";

        private const string INSERT_FUNCIONARIO = @"INSERT INTO TBFuncionario(Nome, Cargo, Ramal) VALUES ('José', 'Desenvolvedor', 123)";

        private const string INSERT_SALA = @"INSERT INTO TBSala(Nome, QuantidadeLugares) VALUES ('Sala de Reunião', 35)";

        private const string INSERT_SALARESERVADA = @"INSERT INTO TBSalaReservada(DataReserva, HoraReserva, Funcionario_Id, Sala_Id) VALUES (GETDATE(), GETDATE(), 1, 1)";


        public static void SeedDatabase()
        {
            Db.Update(RECREATE_SALARESERVADA_TABLE);
            Db.Update(RECREATE_SALA_TABLE);
            Db.Update(RECREATE_FUNCIONARIO_TABLE);

            Db.Update(INSERT_FUNCIONARIO);
            Db.Update(INSERT_SALA);
            Db.Update(INSERT_SALARESERVADA);
        }
    }
}
