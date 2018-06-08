using ControleDeSalas.Application.Feature.Alocacoes;
using ControleDeSalas.Domain.Feature.Funcionarios;
using ControleDeSalas.Domain.Feature.Salas;
using ControleDeSalas.Domain.Feature.Alocacoes;
using ControleDeSalas.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeSalas.Domain.Exceptions;

namespace ControleDeSalas.Infra.Data.Feature.Alocacoes
{
    public class AlocacaoSQLRepository : IAlocacaoRepository
    {
        private string _sqlAdd = @"INSERT INTO TBAlocacao
                                                (DataReserva,
                                                HoraReservaInicio,
                                                HoraReservaFim,
                                                Funcionario_Id,
                                                Sala_Id) 
                                                VALUES 
                                                (@DataReserva, 
                                                @HoraReservaInicio,
                                                @HoraReservaFim,
                                                @Funcionario_Id,
                                                @Sala_Id)";

        private string _sqlUpdate = @"UPDATE  TBAlocacao 
                                                SET 
                                                DataReserva = @DataReserva, 
                                                HoraReservaInicio = @HoraReservaInicio,
                                                HoraReservaFim = @HoraReservaFim,
                                                Funcionario_Id = @Funcionario_Id,
                                                Sala_Id = @Sala_Id
                                                WHERE Id = @Id";

        private string _sqlUpdateRealocar = @"UPDATE TBAlocacao 
                                                        SET 
                                                        DataReserva = @DataReserva, 
                                                        HoraReservaInicio = @HoraReservaInicio,
                                                        HoraReservaFim = @HoraReservaFim,
                                                        Funcionario_Id = @Funcionario_Id,
                                                        Sala_Id = @Sala_Id
                                                        WHERE Id = @Id";

        private string _sqlDelete = @"DELETE FROM TBAlocacao WHERE Id = @Id";

        private string _sqlGetById = @"SELECT a.Id,
                                            a.DataReserva,
                                            a.HoraReservaInicio,
                                            a.HoraReservaFim,
                                            a.Funcionario_Id,
                                            a.Sala_Id,
                                            s.Nome,
                                            s.QuantidadeLugares,
                                            f.Nome,
                                            f.Cargo,
                                            f.Ramal
                                            FROM TBAlocacao as a
                                            INNER JOIN TBSala as s ON s.Id = a.Sala_Id
                                            INNER JOIN TBFuncionario as f ON f.Id = a.Funcionario_Id
                                            WHERE a.Id = @Id";

        private string _sqlGetAll = @"SELECT a.Id,
                                            a.DataReserva,
                                            a.HoraReservaInicio,
                                            a.HoraReservaFim,
                                            a.Funcionario_Id,
                                            a.Sala_Id,
                                            s.Nome,
                                            s.QuantidadeLugares,
                                            f.Nome,
                                            f.Cargo,
                                            f.Ramal
                                            FROM TBAlocacao as a
                                            INNER JOIN TBSala as s ON s.Id = a.Sala_Id
                                            INNER JOIN TBFuncionario as f ON f.Id = a.Funcionario_Id";

        public Alocacao Adicionar(Alocacao entidade)
        {
            entidade.Validar();
            entidade.Id = Db.Insert(_sqlAdd, Take(entidade));
            return entidade;
        }

        public void Realocar(Alocacao entidade)
        {
            entidade.Validar();
            Db.Update(_sqlAdd, Take(entidade));
            
        }
        public void Editar(Alocacao entidade)
        {
            throw new UnsupportedOperationException();
        }

        public void Excluir(int Id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", Id } };
            Db.Delete(_sqlDelete, parms);
        }

        public List<Alocacao> GetAll()
        {
            return Db.GetAll(_sqlGetAll, Make);
        }

        public Alocacao GetById(int Id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", Id } };
            Alocacao sala = Db.Get(_sqlGetById, Make, parms);
            return sala;
        }

        

        private Alocacao Make(IDataReader reader)
        {
            Alocacao sala = new Alocacao();
            sala.Funcionario = new Funcionario();
            sala.Sala = new Sala();

            sala.Id = Convert.ToInt32(reader["Id"]);
            sala.DataReserva = Convert.ToDateTime(reader["DataReserva"]);
            sala.HoraReservaInicio = Convert.ToDateTime(reader["HoraReservaInicio"]);
            sala.HoraReservaFim = Convert.ToDateTime(reader["HoraReservaFim"]);
            sala.Funcionario.Id = Convert.ToInt32(reader["Funcionario_Id"]);
            sala.Sala.Id = Convert.ToInt32(reader["Sala_Id"]);
            return sala;
        }

        private Dictionary<string, object> Take(Alocacao sala)
        {
            return new Dictionary<string, object>
            {
                { "Id", sala.Id },
                { "DataReserva", sala.DataReserva },
                { "HoraReservaInicio", sala.HoraReservaInicio },
                { "HoraReservaFim", sala.HoraReservaFim },
                { "Funcionario_Id", sala.Funcionario.Id },
                { "Sala_Id", sala.Sala.Id }
            };
        }
    }
}
