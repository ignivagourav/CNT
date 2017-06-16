using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNT.Exceptions
{
    public class SQLInvalidRecordException : SQLException
    {
        public SQLInvalidRecordException(string Mes)
            : base(Mes)
        {
        }
    }
}
