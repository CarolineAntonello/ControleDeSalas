using ControleDeSalas.Common.Test.Feature.Salas;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.Salas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Domain.Test.Feature.Salas
{
    [TestFixture]
    public class SalaTests
    {
        Sala _sala;

        [Test]
        public void Domain_Sala_Deveria_Passar_Corretamente()
        {
            _sala = ObjectMother.GetSala();
            _sala.Validar();
            _sala.Should().NotBeNull();
        }

        [Test]
        public void Domain_Sala_Nao_Deveria_Aceitar_Nome_Com_Menos_Quatro_Caracteres()
        {
            _sala = ObjectMother.GetSalaNomeComMenosDeQuatroCaracteres();
            Action action = () =>_sala.Validar();
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Domain_Sala_Nao_Deveria_Aceitar_QuantidadeLugares_Menor_Ou_Igual_A_Zero()
        {
            _sala = ObjectMother.GetSalaQuantidadeLugaresMenorOuIgualAZero();
            Action action = () => _sala.Validar();
            action.Should().Throw<InvalidNumberException>();
        }
    }
}
