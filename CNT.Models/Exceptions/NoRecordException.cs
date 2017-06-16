using CNT.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNT.Exceptions
{
    public class NoRecordException : BusinessException
    {
        public NoRecordException(string Mes)
            : base(Mes)
        {
        }
    }
}
