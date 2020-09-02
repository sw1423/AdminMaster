using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace AdminMaster.UI.Infrastruture
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer container;
        public UnityDependencyResolver(IUnityContainer unityContainer)
        {
            container = unityContainer;
        }
        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.ResolveAll(serviceType);
        }
    }
}