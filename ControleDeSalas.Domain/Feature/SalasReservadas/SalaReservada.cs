using ControleDeSalas.Domain.Abstract;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.Funcionarios;
using ControleDeSalas.Domain.Feature.Salas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Domain.Feature.SalasReservadas
{
    public class SalaReservada : Entidade
    {
        public Funcionario Funcionario;
        public Sala Sala;
        public DateTime DataReserva;
        public DateTime HoraReserva;

        public override void Validar()
        {
            if (Funcionario.Id <= 0)
                throw new IdentifierUndefinedException();

            if(Sala.Id <= 0)
                throw new IdentifierUndefinedException();

            if(DataReserva < DateTime.Now)
                throw new InvalidDateTimeException();

            if(HoraReserva < DateTime.Now)
                throw new InvalidDateTimeException();
        }
    }
}
