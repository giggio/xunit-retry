using System.Collections.Generic;
using Xunit.Sdk;
namespace Xunit
{
    public class RetryAttribute : FactAttribute
    {
        readonly int times;

        public RetryAttribute(int times = 3)
        {
            this.times = times;
        }

        protected override IEnumerable<ITestCommand> EnumerateTestCommands(IMethodInfo method)
        {
            yield return new RetryCommand(method, times);
            yield break;
        }
    }
}
