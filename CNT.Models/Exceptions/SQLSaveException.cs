using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNT.Exceptions
{
    public class SQLSaveException : SQLException
    {
        public SQLSaveException(string Mes)
            : base(Mes)
        {
        }
    }
}
