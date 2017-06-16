using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNT.Exceptions
{
    public class SQLUpdateException : SQLException
    {
        public SQLUpdateException(string Mes)
            : base(Mes)
        {
        }
    }
}
