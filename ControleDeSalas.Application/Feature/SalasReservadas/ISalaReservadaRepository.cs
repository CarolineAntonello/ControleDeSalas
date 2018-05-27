using ControleDeSalas.Domain.Abstract;
using ControleDeSalas.Domain.Feature.SalasReservadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Application.Feature.SalasReservadas
{
    public interface ISalaReservadaRepository : IRepository<SalaReservada>
    {
    }
}
