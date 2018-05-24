using ControleDeSalas.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Domain.Feature.Salas
{
    public class Sala : Entidade
    {
        public string Nome;
        public int QuantidadeLugares;

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
