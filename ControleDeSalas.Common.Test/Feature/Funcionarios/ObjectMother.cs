using ControleDeSalas.Domain.Feature.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Common.Test.Feature.Funcionarios
{
    public partial class ObjectMother
    {
        public static Funcionario GetFuncionario()
        {
            return new Funcionario()
            {
                Nome = "Caroline",
                Cargo = "Estagiária",
                Ramal = 0,
            };
        }

        public static Funcionario GetFuncionarioNomeMenorQueQuatroCaracteres()
        {
            return new Funcionario()
            {
                Nome = "Cah",
                Cargo = "Estagiária",
                Ramal = 0,
            };
        }

        public static Funcionario GetFuncionarioCargoMenorQueQuatroCaracteres()
        {
            return new Funcionario()
            {
                Nome = "Caroline",
                Cargo = "Est",
                Ramal = 0,
            };
        }

        public static Funcionario GetFuncionarioRamalMenorQueZero()
        {
            return new Funcionario()
            {
                Nome = "Caroline",
                Cargo = "Estagiária",
                Ramal = -12,
            };
        }
    }
}
