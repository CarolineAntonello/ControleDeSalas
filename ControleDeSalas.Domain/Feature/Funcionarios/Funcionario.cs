using ControleDeSalas.Domain.Abstract;
using ControleDeSalas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Domain.Feature.Funcionarios
{
    public class Funcionario : Entidade
    {
        public string Nome;
        public string Cargo;
        public int Ramal;

        public override void Validar()
        {
            if (Nome.Length < 4)
                throw new InvalidCaractersException();

            if(Cargo.Length < 4)
                throw new InvalidCaractersException();

            if(Ramal < 0)
                throw new InvalidNumberException();
        }
    }
}
