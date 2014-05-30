using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Utils;

namespace XunitRetry.Generator.SpecflowPlugin
{
    public class XunitRetryTestGeneratorProvider : XunitRetry.Generator.SpecflowPlugin.XUnitTestGeneratorProvider, IUnitTestGeneratorProvider
    {
        public XunitRetryTestGeneratorProvider(CodeDomHelper codeDomHelper) : base(codeDomHelper) { }
        //public override void SetTestMethod(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, string scenarioTitle)
        //{
        //    CodeDomHelper.AddAttribute(testMethod, "Xunit.Retry", new CodeAttributeArgument(new CodePrimitiveExpression(1)));
        //    SetProperty(testMethod, FEATURE_TITLE_PROPERTY_NAME, generationContext.Feature.Title);
        //    SetDescription(testMethod, scenarioTitle);
        //}
        public override void SetTestMethodCategories(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, IEnumerable<string> scenarioCategories)
        {
            base.SetTestMethodCategories(generationContext, testMethod, scenarioCategories);
            var retryCat = scenarioCategories.SingleOrDefault(c => c.StartsWith("retry(", StringComparison.InvariantCultureIgnoreCase));
            int count = 1;
            if (retryCat != null)
            {
                var countValue = Regex.Match(retryCat, @"^retry\((\d+)\)$", RegexOptions.IgnoreCase).Groups[1].Value;
                count = Convert.ToInt32(countValue);
            }
            var existingAttribute = testMethod.CustomAttributes.OfType<CodeAttributeDeclaration>().Single(s => s.Name == "Xunit.FactAttribute");
            testMethod.CustomAttributes.Remove(existingAttribute);
            CodeDomHelper.AddAttribute(testMethod, "Xunit.RetryAttribute", new CodeAttributeArgument(new CodePrimitiveExpression(count)));
        }
    }
}