using ControleDeSalas.Common.Test.Feature.Alocacoes;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.Alocacoes;
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
    public class AlocacaoTests
    {
        Alocacao _alocacao;

        [Test]
        public void Domain_SalaReservada_Deveria_Passar_Corretamente()
        {
            _alocacao = ObjectMother.GetSalaReservada();
            _alocacao.Validar();
            _alocacao.Should().NotBeNull();
        }

        [Test]
        public void Domain_SalaReservada_Nao_Deveria_Aceitar_Sem_Funcionario()
        {
            _alocacao = ObjectMother.GetSalaReservadaSemFuncionario();
            Action action = () => _alocacao.Validar();
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Domain_SalaReservada_Nao_Deveria_Aceitar_Sem_Sala()
        {
            _alocacao = ObjectMother.GetSalaReservadaSemSala();
            Action action = () => _alocacao.Validar();
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Domain_SalaReservada_Nao_Deveria_Aceitar_Data_Menor_Que_Atual()
        {
            _alocacao = ObjectMother.GetSalaReservadaDataMenorQueAtual();
            Action action = () => _alocacao.Validar();
            action.Should().Throw<InvalidDateTimeException>();
        }

        [Test]
        public void Domain_SalaReservada_Nao_Deveria_Aceitar_Hora_Menor_Que_Atual()
        {
            _alocacao = ObjectMother.GetSalaReservadaHoraMenorQueAtual();
            Action action = () => _alocacao.Validar();
            action.Should().Throw<InvalidDateTimeException>();
        }

        [Test]
        public void Domain_SalaReservada_Nao_Deveria_Aceitar_HoraInicio_Maior_Que_HoraFim()
        {
            _alocacao = ObjectMother.GetSalaReservadaHoraReservaInicioMaiorQueHoraReservaFim();
            Action action = () => _alocacao.Validar();
            action.Should().Throw<InvalidDateTimeException>();
        }
    }
}
