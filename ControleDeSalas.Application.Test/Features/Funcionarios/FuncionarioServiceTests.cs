using ControleDeSalas.Application.Feature.Funcionarios;
using ControleDeSalas.Common.Test.Feature.Funcionarios;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.Funcionarios;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Application.Test.Features.Funcionarios
{
    [TestFixture]
    public class FuncionarioServiceTests
    {
        Mock<IFuncionarioRepository> _repository;
        FuncionarioService _service;
        Funcionario _funcionario;

        [SetUp]
        public void Initialize()
        {
            _repository = new Mock<IFuncionarioRepository>();
            _service = new FuncionarioService(_repository.Object);
        }

        [Test]
        public void Service_Funcionario_Deveria_Adicionar_Funcionario_Corretamente()
        {
            _funcionario = ObjectMother.GetFuncionario();
            _repository
                .Setup(f => f.Adicionar(It.IsAny<Funcionario>()))
                .Returns(new Funcionario
                {
                    Id = 1,
                    Nome = _funcionario.Nome,
                    Cargo = _funcionario.Cargo,
                    Ramal = _funcionario.Ramal
                });
            _service.Adicionar(_funcionario);
            _repository.Verify(f => f.Adicionar(_funcionario));
        }

        [Test]
        public void Service_Funcionario_Nao_Deveria_Adicionar_Funcionario_Com_Nome_Menor_Que_Quatro_Caracteres()
        {
            _funcionario = ObjectMother.GetFuncionarioNomeMenorQueQuatroCaracteres();
            Action action = () => _service.Adicionar(_funcionario);
            action.Should().Throw<InvalidCaractersException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_Funcionario_Deveria_Editar_Funcionario_Corretamente()
        {
            _funcionario = ObjectMother.GetFuncionarioComId();
            _repository
                .Setup(f => f.Editar(It.IsAny<Funcionario>()));
            _service.Editar(_funcionario);
            _repository.Verify(f => f.Editar(_funcionario));
        }

        [Test]
        public void Service_Funcionario_Nao_Deveria_Editar_Funcionario_Com_Nome_Menor_Que_Quatro_Caracteres()
        {
            _funcionario = ObjectMother.GetFuncionarioNomeMenorQueQuatroCaracteres();
            Action action = () => _service.Editar(_funcionario);
            action.Should().Throw<InvalidCaractersException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_Funcionario_Deveria_Excluir_Funcionario_Corretamente()
        {
            _funcionario = ObjectMother.GetFuncionarioComId();
            _repository
                .Setup(f => f.Excluir(It.IsAny<int>()));
            _service.Excluir(_funcionario);
            _repository.Verify(f => f.Excluir(_funcionario.Id));
        }

        [Test]
        public void Service_Funcionario_Deveria_Pegar_Funcionario_Por_Id_Corretamente()
        {
            _funcionario = ObjectMother.GetFuncionarioComId();
            _repository
                .Setup(f => f.GetById(It.IsAny<int>()));
            _service.Get(_funcionario.Id);
            _repository.Verify(f => f.GetById(_funcionario.Id));
        }

        [Test]
        public void Service_Funcionario_Deveria_BuscarTodos_Funcionarios_Corretamente()
        {
            List<Funcionario> funcionario = ObjectMother.GetFuncionarios();
            _repository
                .Setup(f => f.GetAll())
                .Returns(funcionario);
           List<Funcionario> recebido =  _service.PegarTodos();
            _repository.Verify(f => f.GetAll());
            recebido.Should().BeEquivalentTo(funcionario);
        }
    }
}
