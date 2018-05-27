using ControleDeSalas.Application.Abstract;
using ControleDeSalas.Domain.Abstract;
using ControleDeSalas.Domain.Feature.SalasReservadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Application.Feature.SalasReservadas
{
    public class SalaReservadaService : Service<SalaReservada>
    {
        ISalaReservadaRepository _repository;
        public SalaReservadaService(ISalaReservadaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
