using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSalas.Domain.Exceptions
{
    public class InvalidDateTimeException : BusinessException
    {
        public InvalidDateTimeException() : base("Data e Horários incorretos!")
        {
        }
    }
}
