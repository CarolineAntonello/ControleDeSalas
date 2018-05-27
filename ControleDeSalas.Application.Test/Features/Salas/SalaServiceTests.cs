using ControleDeSalas.Application.Feature.Salas;
using ControleDeSalas.Common.Test.Feature.Salas;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.Salas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Application.Test.Features.Salas
{
    [TestFixture]
    public class SalaServiceTests
    {
        Mock<ISalaRepository> _repository;
        SalaService _service;
        Sala _sala;

        [SetUp]
        public void Initialize()
        {
            _repository = new Mock<ISalaRepository>();
            _service = new SalaService(_repository.Object);
        }

        [Test]
        public void Service_Sala_Deveria_Adicionar_Sala_Corretamente()
        {
            _sala = ObjectMother.GetSala();
            _repository
                .Setup(f => f.Adicionar(It.IsAny<Sala>()))
                .Returns(new Sala
                {
                    Id = 1,
                    Nome = _sala.Nome,
                    QuantidadeLugares = _sala.QuantidadeLugares
                });
            _service.Adicionar(_sala);
            _repository.Verify(f => f.Adicionar(_sala));
        }

        [Test]
        public void Service_Sala_Nao_Deveria_Adicionar_Sala_Com_Nome_Menor_Que_Quatro_Caracteres()
        {
            _sala = ObjectMother.GetSalaNomeComMenosDeQuatroCaracteres();
            Action action = () => _service.Adicionar(_sala);
            action.Should().Throw<InvalidCaractersException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_Sala_Deveria_Editar_Sala_Corretamente()
        {
            _sala = ObjectMother.GetSalaComId();
            _repository
                .Setup(f => f.Editar(It.IsAny<Sala>()));
            _service.Editar(_sala);
            _repository.Verify(f => f.Editar(_sala));
        }

        [Test]
        public void Service_Sala_Nao_Deveria_Editar_Sala_Com_Nome_Menor_Que_Quatro_Caracteres()
        {
            _sala = ObjectMother.GetSalaNomeComMenosDeQuatroCaracteres();
            Action action = () => _service.Editar(_sala);
            action.Should().Throw<InvalidCaractersException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_Sala_Deveria_Excluir_Sala_Corretamente()
        {
            _sala = ObjectMother.GetSalaComId();
            _repository
                .Setup(f => f.Excluir(It.IsAny<int>()));
            _service.Excluir(_sala);
            _repository.Verify(f => f.Excluir(_sala.Id));
        }

        [Test]
        public void Service_Sala_Deveria_Pegar_Sala_Por_Id_Corretamente()
        {
            _sala = ObjectMother.GetSalaComId();
            _repository
                .Setup(f => f.GetById(It.IsAny<int>()));
            _service.Get(_sala.Id);
            _repository.Verify(f => f.GetById(_sala.Id));
        }

        [Test]
        public void Service_Sala_Deveria_BuscarTodos_Salas_Corretamente()
        {
            List<Sala> funcionario = ObjectMother.GetSalas();
            _repository
                .Setup(f => f.GetAll())
                .Returns(funcionario);
            List<Sala> recebido = _service.PegarTodos();
            _repository.Verify(f => f.GetAll());
            recebido.Should().BeEquivalentTo(funcionario);
        }
    }
}
