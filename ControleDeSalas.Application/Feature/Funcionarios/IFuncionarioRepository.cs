using ControleDeSalas.Domain.Abstract;
using ControleDeSalas.Domain.Feature.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Application.Feature.Funcionarios
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
    }
}
