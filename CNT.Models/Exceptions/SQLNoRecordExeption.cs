using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNT.Exceptions
{
    public class SQLNoRecordExeption : SQLException
    {
        public SQLNoRecordExeption(string Mes)
            : base(Mes)
        {

        }
    }
}
