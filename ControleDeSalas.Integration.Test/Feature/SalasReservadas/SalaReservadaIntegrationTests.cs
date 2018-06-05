using ControleDeSalas.Application.Feature.SalasReservadas;
using ControleDeSalas.Common.Test.Base;
using ControleDeSalas.Common.Test.Feature.SalasReservadas;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.Alocacoes;
using ControleDeSalas.Infra.Data.Feature.SalasReservadas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Integration.Test.Feature.SalasReservadas
{
    [TestFixture]
    public class SalaReservadaIntegrationTests
    {
        ISalaReservadaRepository _repository;
        SalaReservadaService _service;
        Alocacao _salaReservada;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new SalaReservadaSQLRepository();
            _service = new SalaReservadaService(_repository);
        }

        [Test]
        public void Integration_Adiciona_SalaReservada_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservada();
            _service.Adicionar(_salaReservada);
            var Verify = _service.Get(_salaReservada.Id);
            Verify.Should().NotBeNull();
            Verify.Id.Should().Be(_salaReservada.Id);
        }

        [Test]
        public void Integration_Nao_Adiciona_SalaReservada_Com_Hora_Menor_Que_Atual()
        {
            _salaReservada = ObjectMother.GetSalaReservadaHoraMenorQueAtual();
            Action action = () => _service.Adicionar(_salaReservada);
            action.Should().Throw<InvalidDateTimeException>();
        }

        [Test]
        public void Integration_Altera_SalaReservada_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _service.Editar(_salaReservada);
            var Verify = _service.Get(_salaReservada.Id);
            Verify.Should().NotBeNull();
            Verify.Id.Should().Be(_salaReservada.Id);
        }

        [Test]
        public void Integration_Nao_Altera_SalaReservada_Com_Data_Menor_Que_Atual()
        {
            _salaReservada = ObjectMother.GetSalaReservadaDataMenorQueAtual();
            Action action = () => _service.Editar(_salaReservada);
            action.Should().Throw<InvalidDateTimeException>();
        }

        [Test]
        public void Integration_Deletar_SalaReservada_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _service.Excluir(_salaReservada);
            Alocacao recebido = _service.Get(_salaReservada.Id);
            recebido.Should().BeNull();
        }

        [Test]
        public void Integration_Pegar_SalaReservada_Por_Id_Corretamente()
        {
            _salaReservada = _service.Get(1);
            _salaReservada.Should().NotBeNull();
            _salaReservada.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Integration_Pegar_SalaReservada_Por_Id_Incorretamente()
        {
            _salaReservada = _service.Get(200);
            _salaReservada.Should().BeNull();
        }

        [Test]
        public void Integration_Pegar_Todos_Os_SalaReservadas_Corretamente()
        {
            List<Alocacao> funcionarios = _service.PegarTodos();
            funcionarios.Count().Should().BeGreaterThan(0);
        }
    }
}
