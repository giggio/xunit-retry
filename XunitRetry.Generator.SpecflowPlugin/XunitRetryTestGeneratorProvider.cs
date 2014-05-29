using System.CodeDom;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Utils;

namespace XunitRetry.Generator.SpecflowPlugin
{
    public class XunitRetryTestGeneratorProvider : XunitRetry.Generator.SpecflowPlugin.XUnitTestGeneratorProvider, IUnitTestGeneratorProvider
    {
        public XunitRetryTestGeneratorProvider(CodeDomHelper codeDomHelper) : base(codeDomHelper) { }
        public override void SetTestMethod(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, string scenarioTitle)
        {
            CodeDomHelper.AddAttribute(testMethod, "Xunit.Retry", new CodeAttributeArgument(new CodePrimitiveExpression(5)));
            SetProperty(testMethod, FEATURE_TITLE_PROPERTY_NAME, generationContext.Feature.Title);
            SetDescription(testMethod, scenarioTitle);
        }
    }
}