using ControleDeSalas.Common.Test.Feature.SalasReservadas;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.SalasReservadas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Domain.Test.Feature.SalasReservadas
{
    [TestFixture]
    public class SalaReservadaTests
    {
        SalaReservada _salasReservada;

        [Test]
        public void Domain_SalaReservada_Deveria_Passar_Corretamente()
        {
            _salasReservada = ObjectMother.GetSalaReservada();
            _salasReservada.Validar();
            _salasReservada.Should().NotBeNull();
        }

        [Test]
        public void Domain_SalaReservada_Nao_Deveria_Aceitar_Sem_Funcionario()
        {
            _salasReservada = ObjectMother.GetSalaReservadaSemFuncionario();
            Action action = () => _salasReservada.Validar();
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Domain_SalaReservada_Nao_Deveria_Aceitar_Sem_Sala()
        {
            _salasReservada = ObjectMother.GetSalaReservadaSemSala();
            Action action = () => _salasReservada.Validar();
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Domain_SalaReservada_Nao_Deveria_Aceitar_Data_Menor_Que_Atual()
        {
            _salasReservada = ObjectMother.GetSalaReservadaDataMenorQueAtual();
            Action action = () => _salasReservada.Validar();
            action.Should().Throw<InvalidDateTimeException>();
        }

        [Test]
        public void Domain_SalaReservada_Nao_Deveria_Aceitar_Hora_Menor_Que_Atual()
        {
            _salasReservada = ObjectMother.GetSalaReservadaHoraMenorQueAtual();
            Action action = () => _salasReservada.Validar();
            action.Should().Throw<InvalidDateTimeException>();
        }
    }
}
