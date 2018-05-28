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

        private const string INSERT_FUNCIONARIO = @"INSERT INTO TBFuncionario(Nome, Cargo, Ramal) VALUES ('José', 'Desenvolvedor', 123)";


        public static void SeedDatabase()
        {
            Db.Update(RECREATE_FUNCIONARIO_TABLE);

            Db.Update(INSERT_FUNCIONARIO);
        }
    }
}
