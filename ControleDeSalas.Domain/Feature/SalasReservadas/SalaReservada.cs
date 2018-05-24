using ControleDeSalas.Domain.Abstract;
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
            throw new NotImplementedException();
        }
    }
}
