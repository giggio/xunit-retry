using TechTalk.SpecFlow.Infrastructure;
using System.CodeDom;
using BoDi;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.Configuration;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Utils;

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

        public void RegisterConfigurationDefaults(SpecFlowProjectConfiguration specFlowConfiguration)
        {
        }
    }
    public class XunitRetryTestGeneratorProvider : XunitRetry.Generator.SpecflowPlugin.XUnitTestGeneratorProvider, IUnitTestGeneratorProvider
    {
        public XunitRetryTestGeneratorProvider(CodeDomHelper codeDomHelper) : base(codeDomHelper)
        {
        }
        public override void SetTestMethod(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, string scenarioTitle)
        {
            CodeDomHelper.AddAttribute(testMethod, "Xunit.Retry", new CodeAttributeArgument(new CodePrimitiveExpression(5)));
            SetProperty(testMethod, FEATURE_TITLE_PROPERTY_NAME, generationContext.Feature.Title);
            SetDescription(testMethod, scenarioTitle);
        }

    }
}