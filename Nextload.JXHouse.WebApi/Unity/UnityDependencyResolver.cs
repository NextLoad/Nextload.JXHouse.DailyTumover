using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace Nextload.JXHouse.WebApi.Unity
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer unityContainer;
        public UnityDependencyResolver(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }
        public void Dispose()
        {
            this.unityContainer.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.unityContainer.Resolve(serviceType);
            }
            catch (ResolutionFailedException e)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.unityContainer.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = this.unityContainer.CreateChildContainer();
            return new UnityDependencyResolver(child);
        }
    }
}