using ControleDeSalas.Domain.Abstract;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.Funcionarios;
using ControleDeSalas.Domain.Feature.Salas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Domain.Feature.Alocacoes
{
    public class Alocacao : Entidade
    {
        public Funcionario Funcionario { get; set; }
        public Sala Sala { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime HoraReservaInicio { get; set; }
        public DateTime HoraReservaFim { get; set; }

        public override void Validar()
        {
            if (Funcionario.Id <= 0)
                throw new IdentifierUndefinedException();

            if(Sala.Id <= 0)
                throw new IdentifierUndefinedException(); 

            if(DataReserva < DateTime.Now)
                throw new InvalidDateTimeException();

            if(HoraReservaInicio < DateTime.Now)
                throw new InvalidDateTimeException();
        }

    }
}
