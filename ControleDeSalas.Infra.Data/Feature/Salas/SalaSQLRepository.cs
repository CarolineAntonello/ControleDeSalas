using ControleDeSalas.Application.Feature.Salas;
using ControleDeSalas.Domain.Feature.Salas;
using ControleDeSalas.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Infra.Data.Feature.Salas
{
    public class SalaSQLRepository : ISalaRepository
    {
        private string _sqlAdd = @"INSERT INTO 
                                    TBSala
                                    (Nome,
                                    QuantidadeLugares) 
                                    VALUES 
                                    (@Nome, 
                                    @QuantidadeLugares)";

        private string _sqlUpdate = @"UPDATE 
                                    TBSala 
                                    SET 
                                    Nome = @Nome, 
                                    QuantidadeLugares = @QuantidadeLugares
                                    WHERE Id = @Id";

        private string _sqlDelete = @"DELETE FROM TBSala
                                    WHERE Id = @Id";

        private string _sqlGetById = @"SELECT * FROM TBSala WHERE Id = @Id";

        private string _sqlGetAll = @"SELECT 
                                    Id,
                                    Nome,
                                    QuantidadeLugares
                                    FROM
                                    TBSala";

        public Sala Adicionar(Sala entidade)
        {
            entidade.Validar();
            entidade.Id = Db.Insert(_sqlAdd, Take(entidade));
            return entidade;
        }

        public void Editar(Sala entidade)
        {
            entidade.Validar();
            Db.Update(_sqlUpdate, Take(entidade));
        }

        public void Excluir(int Id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", Id } };
            Db.Delete(_sqlDelete, parms);
        }

        public List<Sala> GetAll()
        {
            return Db.GetAll(_sqlGetAll, Make);
        }

        public Sala GetById(int Id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", Id } };
            Sala sala = Db.Get(_sqlGetById, Make, parms);
            return sala;
        }

        private static Func<IDataReader, Sala> Make = reader =>
           new Sala
           {
               Id = Convert.ToInt32(reader["Id"]),
               Nome = reader["Nome"].ToString(),
               QuantidadeLugares = Convert.ToInt32(reader["QuantidadeLugares"])
           };

        private Dictionary<string, object> Take(Sala sala)
        {

            return new Dictionary<string, object>
            {
                { "Id", sala.Id },
                { "Nome", sala.Nome },
                { "QuantidadeLugares", sala.QuantidadeLugares }
            };
        }
    }
}
