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

namespace ControleDeSalas.Infra.Data.Test.Feature.Funcionarios
{
    [TestFixture]
    public class FuncionarioSqlRepositoryTests
    {
        IFuncionarioRepository _repository;
        Funcionario _funcionario;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new FuncionarioSQLRepository();
        }

        [Test]
        public void Repository_Funcionario_Deveria_Adicionar_Corretamente()
        {
            _funcionario = ObjectMother.GetFuncionario();
            _funcionario = _repository.Adicionar(_funcionario);
            _funcionario.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Funcionario_Nao_Deveria_Adicionar_Com_Nome_Menor_Quatro_Caracteres()
        {
            _funcionario = ObjectMother.GetFuncionarioNomeMenorQueQuatroCaracteres();
            Action action = ()=> _repository.Adicionar(_funcionario);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Repository_Funcionario_Deveria_Editar_Corretamente()
        {
            _funcionario = ObjectMother.GetFuncionarioComId();
            _repository.Editar(_funcionario);
            Funcionario funcionario = _repository.GetById(_funcionario.Id);
            funcionario.Id.Should().Be(_funcionario.Id);
        }

        [Test]
        public void Repository_Funcionario_Nao_Deveria_Editar_Com_Nome_Menor_Quatro_Caracteres()
        {
            _funcionario = ObjectMother.GetFuncionarioNomeMenorQueQuatroCaracteres();
            Action action = () => _repository.Editar(_funcionario);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Repository_Funcionario_Deveria_Excluir_Corretamente()
        {
            _funcionario = ObjectMother.GetFuncionarioComId();
            _repository.Excluir(_funcionario.Id);
            Funcionario funcionario = _repository.GetById(_funcionario.Id);
            funcionario.Should().BeNull();
        }

        [Test]
        public void Repository_Funcionario_Deveria_BuscarPorId_Corretamente()
        {
            _funcionario = ObjectMother.GetFuncionarioComId();
            _repository.GetById(_funcionario.Id);
            _funcionario.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Funcionario_Deveria_BuscarTodos_Corretamente()
        {
            List<Funcionario> funcionario = ObjectMother.GetFuncionarios();
            foreach (var item in funcionario)
            {
                _repository.Adicionar(item);
            }
            var list_funcionario = _repository.GetAll();
            list_funcionario.Count.Should().Be(3);
        }
    }
}
