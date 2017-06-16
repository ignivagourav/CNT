using CNT.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNT
{
    public class UnityDependencyLocator : IDependencyLocator
    {
        private readonly IUnityContainer _container;

        public UnityDependencyLocator(IUnityContainer container)
        {
            _container = container;
        }

        public T LocateDependency<T>()
        {
            return (T)_container.Resolve<T>();
        }
    }
}