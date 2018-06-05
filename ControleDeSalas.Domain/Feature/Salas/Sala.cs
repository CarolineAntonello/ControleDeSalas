using ControleDeSalas.Domain.Abstract;
using ControleDeSalas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Domain.Feature.Salas
{
    public class Sala : Entidade
    {
        public string Nome { get; set; }
        public int QuantidadeLugares { get; set; }

        public override void Validar()
        {
            if (Nome.Length < 4)
                throw new InvalidCaractersException();

            if (QuantidadeLugares <= 0)
                throw new InvalidNumberException();
        }
    }
}
