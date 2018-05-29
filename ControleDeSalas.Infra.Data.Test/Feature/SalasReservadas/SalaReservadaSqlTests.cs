using ControleDeSalas.Application.Feature.SalasReservadas;
using ControleDeSalas.Common.Test.Base;
using ControleDeSalas.Common.Test.Feature.SalasReservadas;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.SalasReservadas;
using ControleDeSalas.Infra.Data.Feature.SalasReservadas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Infra.Data.Test.Feature.SalasReservadas
{
    [TestFixture]
    public class SalaReservadaSqlTests
    {
        ISalaReservadaRepository _repository;
        SalaReservada _salaReservada;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new SalaReservadaSQLRepository();
        }

        [Test]
        public void Repository_SalaReservada_Deveria_Adicionar_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservada();
            _salaReservada = _repository.Adicionar(_salaReservada);
            _salaReservada.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_SalaReservada_Nao_Deveria_Adicionar_Com_Data_Menor_Que_Atual()
        {
            _salaReservada = ObjectMother.GetSalaReservadaDataMenorQueAtual();
            Action action = () => _repository.Adicionar(_salaReservada);
            action.Should().Throw<InvalidDateTimeException>();
        }

        [Test]
        public void Repository_Sala_Deveria_Editar_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _repository.Editar(_salaReservada);
            SalaReservada sala = _repository.GetById(_salaReservada.Id);
            sala.Id.Should().Be(_salaReservada.Id);
        }

        [Test]
        public void Repository_SalaReservada_Nao_Deveria_Editar_Com_Data_Menor_Que_Atual()
        {
            _salaReservada = ObjectMother.GetSalaReservadaDataMenorQueAtual();
            Action action = () => _repository.Editar(_salaReservada);
            action.Should().Throw<InvalidDateTimeException>();
        }

        [Test]
        public void Repository_SalaReservada_Deveria_Excluir_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _repository.Excluir(_salaReservada.Id);
            SalaReservada sala_reservada = _repository.GetById(_salaReservada.Id);
            sala_reservada.Should().BeNull();
        }

        [Test]
        public void Repository_SalaReservada_Deveria_BuscarPorId_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _repository.GetById(_salaReservada.Id);
            _salaReservada.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_SalaReservada_Deveria_BuscarTodos_Corretamente()
        {
            List<SalaReservada> salasReservadas = ObjectMother.GetSalasReservadas();
            foreach (var item in salasReservadas)
            {
                _repository.Adicionar(item);
            }
            var list_sala = _repository.GetAll();
            list_sala.Count.Should().Be(3);
        }
    }
}
