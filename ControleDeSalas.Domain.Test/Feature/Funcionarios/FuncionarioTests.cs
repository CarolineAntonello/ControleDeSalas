using ControleDeSalas.Common.Test.Feature.Funcionarios;
using ControleDeSalas.Domain.Exceptions;
using ControleDeSalas.Domain.Feature.Funcionarios;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Domain.Test.Feature.Funcionarios
{
    [TestFixture]
    public class FuncionarioTests
    {
        Funcionario _funcionario;

        [Test]
        public void Domain_Funcionario_Deveria_Passar_Corretamente()
        {
            _funcionario = ObjectMother.GetFuncionario();
            _funcionario.Validar();
            _funcionario.Should().NotBeNull();
        }

        [Test]
        public void Domain_Funcionario_Nao_Deveria_Aceitar_Nome_Com_Menos_De_Quatro_Caracteres()
        {
            _funcionario = ObjectMother.GetFuncionarioNomeMenorQueQuatroCaracteres();
            Action action = () => _funcionario.Validar();
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Domain_Funcionario_Nao_Deveria_Aceitar_Cargo_Com_Menos_De_Quatro_Caracteres()
        {
            _funcionario = ObjectMother.GetFuncionarioCargoMenorQueQuatroCaracteres();
            Action action = () => _funcionario.Validar();
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Domain_Funcionario_Nao_Deveria_Aceitar_Ramal_Menor_Que_Zero()
        {
            _funcionario = ObjectMother.GetFuncionarioRamalMenorQueZero();
            Action action = () => _funcionario.Validar();
            action.Should().Throw<InvalidNumberException>();
        }
    }
}
