using ControleDeSalas.Application.Feature.SalasReservadas;
using ControleDeSalas.Common.Test.Feature.SalasReservadas;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.SalasReservadas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ControleDeSalaReservadas.Application.Test.Features.SalaReservadasReservadas
{
    [TestFixture]
    public class SalaReservadaReservadaTests
    {
        Mock<ISalaReservadaRepository> _repository;
        SalaReservadaService _service;
        SalaReservada _salaReservada;

        [SetUp]
        public void Initialize()
        {
            _repository = new Mock<ISalaReservadaRepository>();
            _service = new SalaReservadaService(_repository.Object);
        }

        [Test]
        public void Service_SalaReservada_Deveria_Adicionar_SalaReservada_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservada();
            _repository
                .Setup(f => f.Adicionar(It.IsAny<SalaReservada>()))
                .Returns(new SalaReservada
                {
                    Id = 1,
                   DataReserva = _salaReservada.DataReserva,
                   HoraReserva = _salaReservada.HoraReserva,
                   Funcionario = _salaReservada.Funcionario,
                   Sala = _salaReservada.Sala
                });
            _service.Adicionar(_salaReservada);
            _repository.Verify(f => f.Adicionar(_salaReservada));
        }

        [Test]
        public void Service_SalaReservada_Nao_Deveria_Adicionar_SalaReservada_Com_Data_Menor_Que_Atual()
        {
            _salaReservada = ObjectMother.GetSalaReservadaDataMenorQueAtual();
            Action action = () => _service.Adicionar(_salaReservada);
            action.Should().Throw<InvalidDateTimeException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_SalaReservada_Deveria_Editar_SalaReservada_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _repository
                .Setup(f => f.Editar(It.IsAny<SalaReservada>()));
            _service.Editar(_salaReservada);
            _repository.Verify(f => f.Editar(_salaReservada));
        }

        [Test]
        public void Service_SalaReservada_Nao_Deveria_Editar_SalaReservada_Com_Com_Data_Menor_Que_Atual()
        {
            _salaReservada = ObjectMother.GetSalaReservadaDataMenorQueAtual();
            Action action = () => _service.Editar(_salaReservada);
            action.Should().Throw<InvalidDateTimeException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_SalaReservada_Deveria_Excluir_SalaReservada_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _repository
                .Setup(f => f.Excluir(It.IsAny<int>()));
            _service.Excluir(_salaReservada);
            _repository.Verify(f => f.Excluir(_salaReservada.Id));
        }

        [Test]
        public void Service_SalaReservada_Deveria_Pegar_SalaReservada_Por_Id_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _repository
                .Setup(f => f.GetById(It.IsAny<int>()));
            _service.Get(_salaReservada.Id);
            _repository.Verify(f => f.GetById(_salaReservada.Id));
        }

        [Test]
        public void Service_SalaReservada_Deveria_BuscarTodos_SalaReservadas_Corretamente()
        {
            List<SalaReservada> funcionario = ObjectMother.GetSalasReservadas();
            _repository
                .Setup(f => f.GetAll())
                .Returns(funcionario);
            List<SalaReservada> recebido = _service.PegarTodos();
            _repository.Verify(f => f.GetAll());
            recebido.Should().BeEquivalentTo(funcionario);
        }
    }
}
