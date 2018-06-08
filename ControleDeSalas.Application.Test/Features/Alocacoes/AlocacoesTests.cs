using ControleDeSalas.Application.Feature.Alocacoes;
using ControleDeSalas.Common.Test.Feature.Alocacoes;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.Alocacoes;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ControleDeSalaReservadas.Application.Test.Features.Alocacoes
{
    [TestFixture]
    public class AlocacoesTests
    {
        Mock<IAlocacaoRepository> _repository;
        AlocacaoService _service;
        Alocacao _salaReservada;

        [SetUp]
        public void Initialize()
        {
            _repository = new Mock<IAlocacaoRepository>();
            _service = new AlocacaoService(_repository.Object);
        }

        [Test]
        public void Service_SalaReservada_Deveria_Adicionar_Locacao_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservada();
            _repository
                .Setup(f => f.Adicionar(It.IsAny<Alocacao>()))
                .Returns(new Alocacao
                {
                    Id = 1,
                   DataReserva = _salaReservada.DataReserva,
                   HoraReservaInicio = _salaReservada.HoraReservaInicio,
                    HoraReservaFim = _salaReservada.HoraReservaFim,
                    Funcionario = _salaReservada.Funcionario,
                   Sala = _salaReservada.Sala
                });
            _service.Adicionar(_salaReservada);
            _repository.Verify(f => f.Adicionar(_salaReservada));
        }

        [Test]
        public void Service_SalaReservada_Nao_Deveria_Adicionar_Locacao_Com_Data_Menor_Que_Atual()
        {
            _salaReservada = ObjectMother.GetSalaReservadaDataMenorQueAtual();
            Action action = () => _service.Adicionar(_salaReservada);
            action.Should().Throw<InvalidDateTimeException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_SalaReservada_Nao_Deveria_Adicionar_Locacao_Com_HoraDeInicio_Maior_Que_HoraDeFim()
        {
            _salaReservada = ObjectMother.GetSalaReservadaHoraReservaInicioMaiorQueHoraReservaFim();
            Action action = () => _service.Adicionar(_salaReservada);
            action.Should().Throw<InvalidDateTimeException>();
            _repository.VerifyNoOtherCalls();
        }

        //[Test]
        //public void Service_SalaReservada_Deveria_Editar_Locacao_Corretamente()
        //{
        //    _salaReservada = ObjectMother.GetSalaReservadaComId();
        //    _repository
        //        .Setup(f => f.Editar(It.IsAny<Alocacao>()));
        //    _service.Editar(_salaReservada);
        //    _repository.Verify(f => f.Editar(_salaReservada));
        //}

        [Test]
        public void Service_SalaReservada_Deveria_Realocar_Locacao_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _repository
                .Setup(f => f.Realocar(It.IsAny<Alocacao>()));
            _service.Editar(_salaReservada);
            _repository.Verify(f => f.Editar(_salaReservada));
        }

        [Test]
        public void Service_SalaReservada_Nao_Deveria_Editar_Locacao_Com_Com_Data_Menor_Que_Atual()
        {
            _salaReservada = ObjectMother.GetSalaReservadaDataMenorQueAtual();
            Action action = () => _service.Editar(_salaReservada);
            action.Should().Throw<InvalidDateTimeException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_SalaReservada_Nao_Deveria_Editar_Locacao_Com_HoraDeInicio_Maior_Que_HoraDeFim()
        {
            _salaReservada = ObjectMother.GetSalaReservadaHoraReservaInicioMaiorQueHoraReservaFim();
            Action action = () => _service.Editar(_salaReservada);
            action.Should().Throw<InvalidDateTimeException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_SalaReservada_Deveria_Excluir_Locacao_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _repository
                .Setup(f => f.Excluir(It.IsAny<int>()));
            _service.Excluir(_salaReservada);
            _repository.Verify(f => f.Excluir(_salaReservada.Id));
        }

        [Test]
        public void Service_SalaReservada_Deveria_Pegar_Locacao_Por_Id_Corretamente()
        {
            _salaReservada = ObjectMother.GetSalaReservadaComId();
            _repository
                .Setup(f => f.GetById(It.IsAny<int>()));
            _service.Get(_salaReservada.Id);
            _repository.Verify(f => f.GetById(_salaReservada.Id));
        }

        [Test]
        public void Service_SalaReservada_Deveria_BuscarTodos_Locacaos_Corretamente()
        {
            List<Alocacao> funcionario = ObjectMother.GetSalasReservadas();
            _repository
                .Setup(f => f.GetAll())
                .Returns(funcionario);
            List<Alocacao> recebido = _service.PegarTodos();
            _repository.Verify(f => f.GetAll());
            recebido.Should().BeEquivalentTo(funcionario);
        }
    }
}
