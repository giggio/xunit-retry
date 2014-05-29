using TechTalk.SpecFlow.Infrastructure;

[assembly: GeneratorPlugin(typeof(CustomXUnit.Generator.SpecflowPlugin.CodedUIGeneratorPlugin))]

namespace CustomXUnit.Generator.SpecflowPlugin
{
    using System.CodeDom;

    using BoDi;

    using TechTalk.SpecFlow.Generator;
    using TechTalk.SpecFlow.Generator.Configuration;
    using TechTalk.SpecFlow.Generator.Plugins;
    using TechTalk.SpecFlow.Generator.UnitTestProvider;
    using TechTalk.SpecFlow.UnitTestProvider;
    using TechTalk.SpecFlow.Utils;

    public class CodedUIGeneratorPlugin : IGeneratorPlugin
    {
        public void RegisterDependencies(ObjectContainer container) { }

        public void RegisterCustomizations(ObjectContainer container, SpecFlowProjectConfiguration generatorConfiguration)
        {
            container.RegisterTypeAs<XUnitCustomCustomTestGeneratorProvider, IUnitTestGeneratorProvider>();
        }

        public void RegisterConfigurationDefaults(SpecFlowProjectConfiguration specFlowConfiguration)
        {
        }
    }
    public class XUnitCustomCustomTestGeneratorProvider : XUnitCustomTestGeneratorProvider
    {
        public XUnitCustomCustomTestGeneratorProvider(CodeDomHelper codeDomHelper) : base(codeDomHelper)
        {
        }
        public override void SetTestMethod(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, string scenarioTitle)
        {
            CodeDomHelper.AddAttribute(testMethod, "XUnitTestProject1.Retry", new CodeAttributeArgument(new CodePrimitiveExpression(5)));
            SetProperty(testMethod, FEATURE_TITLE_PROPERTY_NAME, generationContext.Feature.Title);
            SetDescription(testMethod, scenarioTitle);
        }

    }
}