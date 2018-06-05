using ControleDeSalas.Domain.Feature.Alocacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Common.Test.Feature.Alocacoes
{
    public partial class ObjectMother
    {
        public static Alocacao GetSalaReservada()
        {
            return new Alocacao()
            {
                DataReserva = DateTime.Now.AddDays(10),
                HoraReservaInicio = DateTime.Now.AddDays(10).AddHours(10),
                HoraReservaFim = DateTime.Now.AddDays(10).AddHours(15),
                Funcionario = ControleDeSalas.Common.Test.Feature.Funcionarios.ObjectMother.GetFuncionarioComId(),
                Sala = ControleDeSalas.Common.Test.Feature.Salas.ObjectMother.GetSalaComId(),
            };
        }

        public static Alocacao GetSalaReservadaComId()
        {
            return new Alocacao()
            {
                Id = 1,
                DataReserva = DateTime.Now.AddDays(10),
                HoraReservaInicio = DateTime.Now.AddDays(10).AddHours(10),
                HoraReservaFim = DateTime.Now.AddDays(10).AddHours(15),
                Funcionario = ControleDeSalas.Common.Test.Feature.Funcionarios.ObjectMother.GetFuncionarioComId(),
                Sala = ControleDeSalas.Common.Test.Feature.Salas.ObjectMother.GetSalaComId(),
            };
        }

        public static Alocacao GetSalaReservadaSemFuncionario()
        {
            return new Alocacao()
            {
                DataReserva = DateTime.Now.AddDays(10),
                HoraReservaInicio = DateTime.Now.AddDays(10).AddHours(10),
                HoraReservaFim = DateTime.Now.AddDays(10).AddHours(15),
                Funcionario = ControleDeSalas.Common.Test.Feature.Funcionarios.ObjectMother.GetFuncionario(),
                Sala = ControleDeSalas.Common.Test.Feature.Salas.ObjectMother.GetSalaComId(),
            };
        }

        public static Alocacao GetSalaReservadaSemSala()
        {
            return new Alocacao()
            {
                DataReserva = DateTime.Now.AddDays(10),
                HoraReservaInicio = DateTime.Now.AddDays(10).AddHours(10),
                HoraReservaFim = DateTime.Now.AddDays(10).AddHours(15),
                Funcionario = ControleDeSalas.Common.Test.Feature.Funcionarios.ObjectMother.GetFuncionarioComId(),
                Sala = ControleDeSalas.Common.Test.Feature.Salas.ObjectMother.GetSala(),
            };
        } 

        public static Alocacao GetSalaReservadaDataMenorQueAtual()
        {
            return new Alocacao()
            {
                DataReserva = DateTime.Now.AddDays(-10),
                HoraReservaInicio = DateTime.Now.AddDays(10).AddHours(10),
                HoraReservaFim = DateTime.Now.AddDays(10).AddHours(15),
                Funcionario = ControleDeSalas.Common.Test.Feature.Funcionarios.ObjectMother.GetFuncionarioComId(),
                Sala = ControleDeSalas.Common.Test.Feature.Salas.ObjectMother.GetSalaComId(),
            };
        }

        public static Alocacao GetSalaReservadaHoraMenorQueAtual()
        {
            return new Alocacao()
            {
                DataReserva = DateTime.Now.AddDays(10),
                HoraReservaInicio = DateTime.Now.AddDays(-10).AddHours(-110),
                HoraReservaFim = DateTime.Now.AddDays(10).AddHours(-110),
                Funcionario = ControleDeSalas.Common.Test.Feature.Funcionarios.ObjectMother.GetFuncionarioComId(),
                Sala = ControleDeSalas.Common.Test.Feature.Salas.ObjectMother.GetSalaComId(),
            };
        }

        public static Alocacao GetSalaReservadaHoraReservaInicioMaiorQueHoraReservaFim()
        {
            return new Alocacao()
            {
                DataReserva = DateTime.Now.AddDays(10),
                HoraReservaInicio = DateTime.Now.AddDays(-10).AddHours(15),
                HoraReservaFim = DateTime.Now.AddDays(10).AddHours(5),
                Funcionario = ControleDeSalas.Common.Test.Feature.Funcionarios.ObjectMother.GetFuncionarioComId(),
                Sala = ControleDeSalas.Common.Test.Feature.Salas.ObjectMother.GetSalaComId(),
            };
        }

        public static List<Alocacao> GetSalasReservadas()
        {
            return new List<Alocacao>()
            {
               new Alocacao()
               {
                    DataReserva = DateTime.Now.AddDays(10),
                    HoraReservaInicio = DateTime.Now.AddDays(10).AddHours(10),
                    HoraReservaFim = DateTime.Now.AddDays(10).AddHours(15),
                    Funcionario = ControleDeSalas.Common.Test.Feature.Funcionarios.ObjectMother.GetFuncionarioComId(),
                    Sala = ControleDeSalas.Common.Test.Feature.Salas.ObjectMother.GetSalaComId(),
               },
               new Alocacao()
               {
                    DataReserva = DateTime.Now.AddDays(15),
                    HoraReservaInicio = DateTime.Now.AddDays(10).AddHours(10),
                    HoraReservaFim = DateTime.Now.AddDays(10).AddHours(15),
                    Funcionario = ControleDeSalas.Common.Test.Feature.Funcionarios.ObjectMother.GetFuncionarioComId(),
                    Sala = ControleDeSalas.Common.Test.Feature.Salas.ObjectMother.GetSalaComId(),
               },
            };
        }
    }
}
