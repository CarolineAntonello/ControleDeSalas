using ControleDeSalas.Application.Feature.Salas;
using ControleDeSalas.Common.Test.Base;
using ControleDeSalas.Common.Test.Feature.Salas;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.Salas;
using ControleDeSalas.Infra.Data.Feature.Salas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Integration.Test.Feature.Salas
{
    [TestFixture]
    public class SalaIntegrationTests
    {
        ISalaRepository _repository;
        SalaService _service;
        Sala _sala;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new SalaSQLRepository();
            _service = new SalaService(_repository);
        }

        [Test]
        public void Integration_Adiciona_Sala_Corretamente()
        {
            _sala = ObjectMother.GetSala();
            _service.Adicionar(_sala);
            var Verify = _service.Get(_sala.Id);
            Verify.Should().NotBeNull();
            Verify.Id.Should().Be(_sala.Id);
        }

        [Test]
        public void Integration_Nao_Adiciona_Nome_Sala_Com_Menos_De_Quatro_Caracteres()
        {
            _sala = ObjectMother.GetSalaNomeComMenosDeQuatroCaracteres();
            Action action = () => _service.Adicionar(_sala);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Integration_Altera_Sala_Corretamente()
        {
            _sala = ObjectMother.GetSalaComId();
            _service.Editar(_sala);
            var Verify = _service.Get(_sala.Id);
            Verify.Should().NotBeNull();
            Verify.Id.Should().Be(_sala.Id);
        }

        [Test]
        public void Integration_Nao_Altera_Nome_Sala_Com_Menos_De_Quatro_Caracteres()
        {
            _sala = ObjectMother.GetSalaNomeComMenosDeQuatroCaracteres();
            Action action = () => _service.Editar(_sala);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Integration_Deletar_Sala_Corretamente()
        {
            _sala = ObjectMother.GetSalaComId();
            _service.Excluir(_sala);
            Sala recebido = _service.Get(_sala.Id);
            recebido.Should().BeNull();
        }

        [Test]
        public void Integration_Pegar_Sala_Por_Id_Corretamente()
        {
            _sala = _service.Get(1);
            _sala.Should().NotBeNull();
            _sala.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Integration_Pegar_Sala_Por_Id_Incorretamente()
        {
            _sala = _service.Get(200);
            _sala.Should().BeNull();
        }

        [Test]
        public void Integration_Pegar_Todas_As_Salas_Corretamente()
        {
            List<Sala> funcionarios = _service.PegarTodos();
            funcionarios.Count().Should().BeGreaterThan(0);
        }
    }
}
