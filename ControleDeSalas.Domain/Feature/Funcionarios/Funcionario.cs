using ControleDeSalas.Domain.Abstract;
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
        public string cargo;
        public int Ramal;

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
