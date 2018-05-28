using ControleDeSalas.Application.Feature.Funcionarios;
using ControleDeSalas.Domain.Abstract;
using ControleDeSalas.Domain.Feature.Funcionarios;
using ControleDeSalas.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Infra.Data.Feature.Funcionarios
{
    public class FuncionarioSQLRepository : IFuncionarioRepository
    {
        private string _sqlAdd = @"INSERT INTO 
                                    TBFuncionario
                                    (Nome,
                                    Cargo,
                                    Ramal) 
                                    VALUES 
                                    (@Nome, 
                                    @Cargo,
                                    @Ramal)";

        private string _sqlUpdate = @"UPDATE 
                                    TBFuncionario 
                                    SET 
                                    Nome = @Nome, 
                                    Cargo = @Cargo, 
                                    Ramal = @Ramal
                                    WHERE Id = @Id";

        private string _sqlDelete = @"DELETE FROM TBFuncionario
                                    WHERE Id = @Id";

        private string _sqlGetById = @"SELECT * FROM TBFuncionario WHERE Id = @Id";

        private string _sqlGetAll = @"SELECT 
                                    Id,
                                    Nome,
                                    Cargo,
                                    Ramal
                                    FROM
                                    TBFuncionario";

        public Funcionario Adicionar(Funcionario entidade)
        {
            entidade.Validar();
            entidade.Id = Db.Insert(_sqlAdd, Take(entidade));
            return entidade;
        }

        public void Editar(Funcionario entidade)
        {
            entidade.Validar();
            Db.Update(_sqlUpdate, Take(entidade));
        }

        public void Excluir(int Id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", Id } };
            Db.Delete(_sqlDelete, parms);
        }

        public List<Funcionario> GetAll()
        {
            return Db.GetAll(_sqlGetAll, Make);
        }

        public Funcionario GetById(int Id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", Id } };
            Funcionario funcionario = Db.Get(_sqlGetById, Make, parms);
            return funcionario;
        }

        private static Func<IDataReader, Funcionario> Make = reader =>
           new Funcionario
           {
               Id = Convert.ToInt32(reader["Id"]),
               Nome = reader["Nome"].ToString(),
               Cargo = reader["Cargo"].ToString(),
               Ramal = Convert.ToInt32(reader["Ramal"])
           };

        private Dictionary<string, object> Take(Funcionario funcionario)
        {

            return new Dictionary<string, object>
            {
                { "Id", funcionario.Id },
                { "Nome", funcionario.Nome },
                { "Cargo", funcionario.Cargo },
                { "Ramal", funcionario.Ramal }
            };
        }
    }
}
