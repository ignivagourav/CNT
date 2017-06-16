using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNT.Models.Exceptions
{
    public class DeleteException : BusinessException
    {
        public DeleteException(string Mes)
            : base(Mes)
        {
        }
    }
}
