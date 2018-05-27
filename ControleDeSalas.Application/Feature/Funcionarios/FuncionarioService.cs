using ControleDeSalas.Application.Abstract;
using ControleDeSalas.Domain.Abstract;
using ControleDeSalas.Domain.Feature.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Application.Feature.Funcionarios
{
    public class FuncionarioService : Service<Funcionario>
    {
        IFuncionarioRepository _repository;
        public FuncionarioService(IFuncionarioRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
