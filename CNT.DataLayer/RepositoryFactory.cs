using CNT.Models.DataInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNT.DataLayer
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private Context _context;

        public RepositoryFactory(IContext context)
        {
            _context = (Context)context;
        }
    }
}
