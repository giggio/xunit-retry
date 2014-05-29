using TechTalk.SpecFlow.Infrastructure;
using BoDi;
using TechTalk.SpecFlow.Generator.Configuration;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;

[assembly: GeneratorPlugin(typeof(XunitRetry.Generator.SpecflowPlugin.XunitRetryGeneratorPlugin))]

namespace XunitRetry.Generator.SpecflowPlugin
{
    public class XunitRetryGeneratorPlugin : IGeneratorPlugin
    {
        public void RegisterDependencies(ObjectContainer container) { }

        public void RegisterCustomizations(ObjectContainer container, SpecFlowProjectConfiguration generatorConfiguration)
        {
            container.RegisterTypeAs<XunitRetryTestGeneratorProvider, IUnitTestGeneratorProvider>();
        }

        public void RegisterConfigurationDefaults(SpecFlowProjectConfiguration specFlowConfiguration) { }
    }
}