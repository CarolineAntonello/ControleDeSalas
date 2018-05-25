using ControleDeSalas.Domain.Feature.Salas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Common.Test.Feature.Salas
{
    public partial class ObjectMother
    {
        public static Sala GetSala()
        {
            return new Sala()
            {
                Nome = "Sala de Treinamento",
                QuantidadeLugares = 36,
            };
        }

        public static Sala GetSalaNomeComMenosDeQuatroCaracteres()
        {
            return new Sala()
            {
                Nome = "Sa",
                QuantidadeLugares = 36,
            };
        }

        public static Sala GetSalaQuantidadeLugaresMenorOuIgualAZero()
        {
            return new Sala()
            {
                Nome = "Sala de Reunião",
                QuantidadeLugares = 0,
            };
        }
    }
}
