using NRules.Fluent;
using NRules.Fluent.Dsl;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRules.Integration.SimpleInjector
{
     public class SimpleInjectorRuleActivator : IRuleActivator
    {
        private readonly Container container;

        public SimpleInjectorRuleActivator(Container container)
        {
            this.container = container;
        }

        public IEnumerable<Rule> Activate(Type type)
        {
            if (container.GetRegistration(type) != null)
            {
                return new List<Rule> { (Rule)container.GetInstance(type) };
            }

            return ActivateDefault(type);
        }

        private static IEnumerable<Rule> ActivateDefault(Type type)
        {
            yield return (Rule)Activator.CreateInstance(type);
        }
    }
}
