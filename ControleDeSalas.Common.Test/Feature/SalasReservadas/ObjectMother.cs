using ControleDeSalas.Domain.Feature.SalasReservadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Common.Test.Feature.SalasReservadas
{
    public partial class ObjectMother
    {
        public static SalaReservada GetSalaReservada()
        {
            return new SalaReservada()
            {
                DataReserva = DateTime.Now.AddDays(10),
                HoraReserva = DateTime.Now.AddDays(10).AddHours(10),
                Funcionario = ControleDeSalas.Common.Test.Feature.Funcionarios.ObjectMother.GetFuncionarioComId(),
                Sala = ControleDeSalas.Common.Test.Feature.Salas.ObjectMother.GetSalaComId(),
            };
        }

        public static SalaReservada GetSalaReservadaSemFuncionario()
        {
            return new SalaReservada()
            {
                DataReserva = DateTime.Now.AddDays(10),
                HoraReserva = DateTime.Now.AddDays(10).AddHours(10),
                Funcionario = ControleDeSalas.Common.Test.Feature.Funcionarios.ObjectMother.GetFuncionario(),
                Sala = ControleDeSalas.Common.Test.Feature.Salas.ObjectMother.GetSalaComId(),
            };
        }

        public static SalaReservada GetSalaReservadaSemSala()
        {
            return new SalaReservada()
            {
                DataReserva = DateTime.Now.AddDays(10),
                HoraReserva = DateTime.Now.AddDays(10).AddHours(10),
                Funcionario = ControleDeSalas.Common.Test.Feature.Funcionarios.ObjectMother.GetFuncionarioComId(),
                Sala = ControleDeSalas.Common.Test.Feature.Salas.ObjectMother.GetSala(),
            };
        }

        public static SalaReservada GetSalaReservadaDataMenorQueAtual()
        {
            return new SalaReservada()
            {
                DataReserva = DateTime.Now.AddDays(-10),
                HoraReserva = DateTime.Now.AddDays(10).AddHours(10),
                Funcionario = ControleDeSalas.Common.Test.Feature.Funcionarios.ObjectMother.GetFuncionarioComId(),
                Sala = ControleDeSalas.Common.Test.Feature.Salas.ObjectMother.GetSalaComId(),
            };
        }

        public static SalaReservada GetSalaReservadaHoraMenorQueAtual()
        {
            return new SalaReservada()
            {
                DataReserva = DateTime.Now.AddDays(10),
                HoraReserva = DateTime.Now.AddDays(-10).AddHours(-110),
                Funcionario = ControleDeSalas.Common.Test.Feature.Funcionarios.ObjectMother.GetFuncionarioComId(),
                Sala = ControleDeSalas.Common.Test.Feature.Salas.ObjectMother.GetSalaComId(),
            };
        }
    }
}
