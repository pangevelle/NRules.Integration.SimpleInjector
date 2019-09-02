using NRules.Extensibility;
using SimpleInjector;
using System;

namespace NRules.Integration.SimpleInjector
{
    public class SimpleInjectorResolver : IDependencyResolver
    {
        readonly Container Container;

        public SimpleInjectorResolver(Container container)
        {
            this.Container = container;
        }

        public object Resolve(IResolutionContext context, Type serviceType)
        {
            return Container.GetInstance(serviceType);
        }
    }
}
