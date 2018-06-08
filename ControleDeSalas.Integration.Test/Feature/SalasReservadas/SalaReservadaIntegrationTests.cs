using ControleDeSalas.Application.Feature.Alocacoes;
using ControleDeSalas.Common.Test.Base;
using ControleDeSalas.Common.Test.Feature.Alocacoes;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.Alocacoes;
using ControleDeSalas.Infra.Data.Feature.Alocacoes;
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
        IAlocacaoRepository _repository;
        AlocacaoService _service;
        Alocacao _salaReservada;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new AlocacaoSQLRepository();
            _service = new AlocacaoService(_repository);
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
        public void Integration_Realocar_SalaReservada_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _service.Realocar(_salaReservada);
            var Verify = _service.Get(_salaReservada.Id);
            Verify.Should().NotBeNull();
            Verify.Id.Should().Be(_salaReservada.Id);
        }

        [Test]
        public void Integration_Altera_SalaReservada_Com_Excecao()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            Action action = ()=> _service.Editar(_salaReservada);
            action.Should().Throw<UnsupportedOperationException>();
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
