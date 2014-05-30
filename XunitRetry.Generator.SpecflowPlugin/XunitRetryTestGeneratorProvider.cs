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
        public override void SetTestClassCategories(TestClassGenerationContext generationContext, IEnumerable<string> featureCategories)
        {
            base.SetTestClassCategories(generationContext, featureCategories);
            var count = GetRetryCount(featureCategories);
            if (count > 1) generationContext.CustomData["featureRetryCount"] = count;
        }
        public override void SetTestMethod(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, string scenarioTitle)
        {
            SetProperty(testMethod, FEATURE_TITLE_PROPERTY_NAME, generationContext.Feature.Title);
            SetDescription(testMethod, scenarioTitle);

            var count = !generationContext.CustomData.ContainsKey("featureRetryCount") ? 1 : Convert.ToInt32(generationContext.CustomData["featureRetryCount"]);

            if (count > 1)
                CodeDomHelper.AddAttribute(testMethod, "Xunit.RetryAttribute", new CodeAttributeArgument(new CodePrimitiveExpression(count)));
            else
                CodeDomHelper.AddAttribute(testMethod, FACT_ATTRIBUTE);
        }
        public override void SetTestMethodCategories(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, IEnumerable<string> scenarioCategories)
        {
            base.SetTestMethodCategories(generationContext, testMethod, scenarioCategories);
            var count = GetRetryCount(scenarioCategories);
            if (count <= 1) return;
            var existingAttribute = testMethod.CustomAttributes.OfType<CodeAttributeDeclaration>().SingleOrDefault(s => s.Name == "Xunit.RetryAttribute");
            if (existingAttribute != null) testMethod.CustomAttributes.Remove(existingAttribute);
            existingAttribute = testMethod.CustomAttributes.OfType<CodeAttributeDeclaration>().SingleOrDefault(s => s.Name == "Xunit.FactAttribute");
            if (existingAttribute != null) testMethod.CustomAttributes.Remove(existingAttribute);
            CodeDomHelper.AddAttribute(testMethod, "Xunit.RetryAttribute", new CodeAttributeArgument(new CodePrimitiveExpression(count)));
        }
        private int GetRetryCount(IEnumerable<string> tags)
        {
            var retryCat = tags.SingleOrDefault(c => c.StartsWith("retry(", StringComparison.InvariantCultureIgnoreCase));
            int count = 1;
            if (retryCat != null)
            {
                var countValue = Regex.Match(retryCat, @"^retry\((\d+)\)$", RegexOptions.IgnoreCase).Groups[1].Value;
                count = Convert.ToInt32(countValue);
            }
            return count;
        }
    }
}