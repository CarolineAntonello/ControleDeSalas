using ControleDeSalas.Domain.Abstract;
using ControleDeSalas.Domain.Feature.Salas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Application.Feature.Salas
{
    public interface ISalaRepository : IRepository<Sala>
    {
    }
}
