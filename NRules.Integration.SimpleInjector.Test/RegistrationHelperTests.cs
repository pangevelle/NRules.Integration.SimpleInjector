using NRules.Fluent.Dsl;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestAssembly1;
using TestAssembly2;
using Xunit;

namespace NRules.Integration.SimpleInjector.Test
{
    public class RegistrationHelperTests
    {
        [Fact]
        public void RegisterSingleAssembly()
        {
            Container container = new Container();
            Assembly rulesAssembly = typeof(TestAssembly1.TestRule1).Assembly;
            container.RegisterRules(rulesAssembly);

            Assert.Single(container.GetAllInstances<Rule>());
            Assert.IsType<TestAssembly1.TestRule1>(container.GetInstance<TestAssembly1.TestRule1>());
        }

        [Fact]
        public void RegisterMultipleAssemblies()
        {
            Container container = new Container();
            List<Assembly> assemblies = new List<Assembly> { typeof(TestAssembly1.TestRule1).Assembly, typeof(TestAssembly2.TestRule1).Assembly };

            container.RegisterRules(assemblies);

            Assert.Equal(3, container.GetAllInstances<Rule>().Count());
        }

        [Fact]
        public void RegisterWithScanAction()
        {
            Container container = new Container();
          
            container.RegisterRules(x => x.AssemblyOf<TestAssembly1.TestRule1>());

            Assert.Single(container.GetAllInstances<Rule>());
            Assert.IsType<TestAssembly1.TestRule1>(container.GetInstance<TestAssembly1.TestRule1>());
        }


    }
}
