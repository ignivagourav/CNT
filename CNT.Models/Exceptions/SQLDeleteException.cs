using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNT.Exceptions
{
    public class SQLDeleteException : SQLException
    {
        public SQLDeleteException(string Mes)
            : base(Mes)
        {
        }
    }
}
