using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace NRules.Integration.SimpleInjector.Test
{
    public class RuelActivatorTests
    {
        [Fact]
        public void RegisteredTypeIsActivatedInList()
        {
            Container container = new Container();
            container.Register<TestAssembly1.TestRule1>();

            SimpleInjectorRuleActivator simpleInjectorRuleActivator = new SimpleInjectorRuleActivator(container);
            var activatedRules = simpleInjectorRuleActivator.Activate(typeof(TestAssembly1.TestRule1));

            Assert.Single(activatedRules);
            Assert.IsType<TestAssembly1.TestRule1>(activatedRules.First());
        }

        [Fact]
        public void UnregisteredTypeIsActivatedInList()
        {
            Container container = new Container();

            SimpleInjectorRuleActivator simpleInjectorRuleActivator = new SimpleInjectorRuleActivator(container);
            var activatedRules = simpleInjectorRuleActivator.Activate(typeof(TestAssembly1.TestRule1));

            Assert.Single(activatedRules);
            Assert.IsType<TestAssembly1.TestRule1>(activatedRules.First());
        }
    }
}
