using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Domain.Exceptions
{
    public class InvalidNumberException : BusinessException
    {
        public InvalidNumberException() : base("Número inválido! Precisa ser maior que 0")
        {
        }
    }
}
