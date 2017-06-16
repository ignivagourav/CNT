using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNT.Models.Exceptions
{
  public  class InvalidCredentials:BusinessException
    {
      public InvalidCredentials(string mes)
          : base(mes)
      {
      }
    }
}
