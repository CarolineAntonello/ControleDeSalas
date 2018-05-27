using ControleDeSalas.Application.Abstract;
using ControleDeSalas.Domain.Abstract;
using ControleDeSalas.Domain.Feature.Salas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Application.Feature.Salas
{
    public class SalaService : Service<Sala>
    {
        ISalaRepository _repository;
        public SalaService(ISalaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
