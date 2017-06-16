using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNT.Models
{
    public interface IDependencyLocator
    {
        T LocateDependency<T>();
    }
}
