using CNT.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNT.Exceptions
{
    public class SQLException:BaseException
    {
        public SQLException(string Mes):base(Mes)
        {
            
        }
    }
}
