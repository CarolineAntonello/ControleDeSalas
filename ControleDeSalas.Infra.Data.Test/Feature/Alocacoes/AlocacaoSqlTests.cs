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

namespace ControleDeSalas.Infra.Data.Test.Feature.Alocacoes
{
    [TestFixture]
    public class AlocacaoSqlTests
    {
        IAlocacaoRepository _repository;
        Alocacao _salaReservada;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new AlocacaoSQLRepository();
        }

        [Test]
        public void Repository_Alocacao_Deveria_Adicionar_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservada();
            _salaReservada = _repository.Adicionar(_salaReservada);
            _salaReservada.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Alocacao_Nao_Deveria_Adicionar_Com_Data_Menor_Que_Atual()
        {
            _salaReservada = ObjectMother.GetSalaReservadaDataMenorQueAtual();
            Action action = () => _repository.Adicionar(_salaReservada);
            action.Should().Throw<InvalidDateTimeException>();
        }

        [Test]
        public void Repository_Alocacao_Deveria_Editar_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _salaReservada.Funcionario.Id = 1;
            _repository.Editar(_salaReservada);
            Alocacao sala = _repository.GetById(_salaReservada.Id);
            sala.Id.Should().Be(_salaReservada.Id);
        }

        [Test]
        public void Repository_Alocacao_Nao_Deveria_Editar_Com_Data_Menor_Que_Atual()
        {
            _salaReservada = ObjectMother.GetSalaReservadaDataMenorQueAtual();
            Action action = () => _repository.Editar(_salaReservada);
            action.Should().Throw<InvalidDateTimeException>();
        }

        [Test]
        public void Repository_Alocacao_Deveria_Excluir_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _repository.Excluir(_salaReservada.Id);
            Alocacao sala_reservada = _repository.GetById(_salaReservada.Id);
            sala_reservada.Should().BeNull();
        }

        [Test]
        public void Repository_Alocacao_Deveria_BuscarPorId_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _repository.GetById(_salaReservada.Id);
            _salaReservada.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Alocacao_Deveria_BuscarTodos_Corretamente()
        {
            List<Alocacao> salasReservadas = ObjectMother.GetSalasReservadas();
            foreach (var item in salasReservadas)
            {
                _repository.Adicionar(item);
            }
            var list_sala = _repository.GetAll();
            list_sala.Count.Should().Be(3);
        }
    }
}
