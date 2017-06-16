using CNT.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNT.Exceptions
{
    public class UserInvalidEmailExceptions : BaseException
    {
        public UserInvalidEmailExceptions(string Mes)
            : base(Mes)
        {
            
        }
    }
}
