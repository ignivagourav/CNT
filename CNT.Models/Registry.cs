using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNT.Models.DataInterfaces;
using CNT.Models.BusinessInterfaces;

namespace CNT.Models
{
    public static class Registry
    {
        public static IDependencyLocator DependencyLocator;

        public static IContext Context
        {
            get
            {
                return DependencyLocator.LocateDependency<IContext>();
            }
        }

        public static IRepositoryFactory RepositoryFactory
        {
            get
            {
                return DependencyLocator.LocateDependency<IRepositoryFactory>();
            }
        }
        public static IServiceFactory ServiceFactory
        {
            get
            {
                return DependencyLocator.LocateDependency<IServiceFactory>();
            }
        }

    }
}
