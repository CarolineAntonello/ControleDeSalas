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

        public static Sala GetSalaComId()
        {
            return new Sala()
            {
                Id = 1,
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

        public static List<Sala> GetSalas()
        {
            return new List<Sala>()
            {
                new Sala()
                {
                    Nome = "Sala de Reunião",
                    QuantidadeLugares = 30,
                },

                new Sala()
                {
                    Nome = "Sala de Conferência",
                    QuantidadeLugares = 20,
                },

            };
        }
    }
}
