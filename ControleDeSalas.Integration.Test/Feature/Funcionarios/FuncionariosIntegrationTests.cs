using ControleDeSalas.Application.Feature.Funcionarios;
using ControleDeSalas.Common.Test.Base;
using ControleDeSalas.Common.Test.Feature.Funcionarios;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.Funcionarios;
using ControleDeSalas.Infra.Data.Feature.Funcionarios;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Integration.Test.Feature.Funcionarios
{
    [TestFixture]
    public class FuncionariosIntegrationTests
    {
        IFuncionarioRepository _repository;
        FuncionarioService _service;
        Funcionario _funcionario;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new FuncionarioSQLRepository();
            _service = new FuncionarioService(_repository);
        }

        [Test]
        public void Integration_Adiciona_Funcionario_Corretamente()
        {
            _funcionario = ObjectMother.GetFuncionario();
            _service.Adicionar(_funcionario);
            var Verify = _service.Get(_funcionario.Id);
            Verify.Should().NotBeNull();
            Verify.Id.Should().Be(_funcionario.Id);
        }

        [Test]
        public void Integration_Adiciona_Nome_Funcionario_Com_Menos_De_Quatro_Caracteres()
        {
            _funcionario = ObjectMother.GetFuncionarioNomeMenorQueQuatroCaracteres();
            Action action = () => _service.Adicionar(_funcionario);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Integration_Altera_Funcionario_Corretamente()
        {
            _funcionario = ObjectMother.GetFuncionarioComId();
            _service.Editar(_funcionario);
            var Verify = _service.Get(_funcionario.Id);
            Verify.Should().NotBeNull();
            Verify.Id.Should().Be(_funcionario.Id);
        }

        [Test]
        public void Integration_Altera_Nome_Funcionario_Com_Menos_De_Quatro_Caracteres()
        {
            _funcionario = ObjectMother.GetFuncionarioNomeMenorQueQuatroCaracteres();
            Action action = () => _service.Editar(_funcionario);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Integration_Deletar_Funcionario_Corretamente()
        {
            _funcionario = ObjectMother.GetFuncionarioComId();
            _service.Excluir(_funcionario);
            Funcionario recebido = _service.Get(_funcionario.Id);
            recebido.Should().BeNull();
        }

        [Test]
        public void Integration_Pegar_Funcionario_Por_Id_Corretamente()
        {
            _funcionario = _service.Get(1);
            _funcionario.Should().NotBeNull();
            _funcionario.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Integration_Pegar_Funcionario_Por_Id_Incorretamente()
        {
            _funcionario = _service.Get(200);
            _funcionario.Should().BeNull();
        }

        [Test]
        public void Integration_Pegar_Todos_Os_Funcionarios_Corretamente()
        {
            List<Funcionario> funcionarios = _service.PegarTodos();
            funcionarios.Count().Should().BeGreaterThan(0);
        }
    }
}
