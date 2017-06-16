using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNT.Models.Exceptions
{
    public class BusinessException : BaseException
    {
        public BusinessException(string Mes):base(Mes)
        {
        }
    }
}
