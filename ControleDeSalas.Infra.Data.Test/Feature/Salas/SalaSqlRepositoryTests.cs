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

namespace ControleDeSalas.Infra.Data.Test.Feature.Salas
{
    [TestFixture]
    public class SalaSqlRepositoryTests
    {
        ISalaRepository _repository;
        Sala _sala;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new SalaSQLRepository();
        }

        [Test]
        public void Repository_Sala_Deveria_Adicionar_Corretamente()
        {
            _sala = ObjectMother.GetSala();
            _sala = _repository.Adicionar(_sala);
            _sala.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Sala_Nao_Deveria_Adicionar_Com_Nome_Menor_Quatro_Caracteres()
        {
            _sala = ObjectMother.GetSalaNomeComMenosDeQuatroCaracteres();
            Action action = () => _repository.Adicionar(_sala);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Repository_Sala_Deveria_Editar_Corretamente()
        {
            _sala = ObjectMother.GetSalaComId();
            _repository.Editar(_sala);
            Sala sala = _repository.GetById(_sala.Id);
            sala.Id.Should().Be(_sala.Id);
        }

        [Test]
        public void Repository_Sala_Nao_Deveria_Editar_Com_Nome_Menor_Quatro_Caracteres()
        {
            _sala = ObjectMother.GetSalaNomeComMenosDeQuatroCaracteres();
            Action action = () => _repository.Editar(_sala);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Repository_Sala_Deveria_Excluir_Corretamente()
        {
            _sala = ObjectMother.GetSalaComId();
            _repository.Excluir(_sala.Id);
            Sala sala = _repository.GetById(_sala.Id);
            sala.Should().BeNull();
        }

        [Test]
        public void Repository_Sala_Deveria_BuscarPorId_Corretamente()
        {
            _sala = ObjectMother.GetSalaComId();
            _repository.GetById(_sala.Id);
            _sala.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Sala_Deveria_BuscarTodos_Corretamente()
        {
            List<Sala> salas = ObjectMother.GetSalas();
            foreach (var item in salas)
            {
                _repository.Adicionar(item);
            }
            var list_sala = _repository.GetAll();
            list_sala.Count.Should().Be(3);
        }
    }
}
