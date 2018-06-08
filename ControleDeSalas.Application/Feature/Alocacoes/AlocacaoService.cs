using ControleDeSalas.Application.Abstract;
using ControleDeSalas.Domain.Abstract;
using ControleDeSalas.Domain.Feature.Alocacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Application.Feature.Alocacoes
{
    public class AlocacaoService : Service<Alocacao>
    {
        IAlocacaoRepository _repository;
        public AlocacaoService(IAlocacaoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Alocacao Realocar(Alocacao entidade)
        {
            entidade.Validar();
            _repository.Realocar(entidade);
            return entidade;
        }
        
    }
}
