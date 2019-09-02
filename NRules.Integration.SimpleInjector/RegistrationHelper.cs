using NRules.Fluent;
using NRules.Fluent.Dsl;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRules.Integration.SimpleInjector
{
    public static class RegistrationHelper
    {
        public static void RegisterRules(this Container container, Assembly assembly)
        {
            container.RegisterRules(new List<Assembly> { assembly });
        }

        public static void RegisterRules(this Container container, IEnumerable<Assembly> assemblies)
        {
            container.Collection.Register(typeof(Rule), assemblies);
        }

        public static void RegisterRules(this Container container, Action<IRuleTypeScanner> scanAction)
        {
            var scanner = new RuleTypeScanner();
            scanAction(scanner);
            var ruleTypes = scanner.GetRuleTypes();
            container.Collection.Register(typeof(Rule), ruleTypes);
        }
    }
}
