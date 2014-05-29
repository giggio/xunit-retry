using Xunit.Sdk;

namespace Xunit
{
    public class RetryCommand : FactCommand
    {
        private int times;

        public RetryCommand(IMethodInfo method, int times) : base(method)
        {
            this.times = times;
        }
        public override MethodResult Execute(object testClass)
        {
            int i = 1;
            do
            {
                try
                {
                    return base.Execute(testClass);
                }
                catch if (i < times)
                {
                }
                i++;
            } while (true);
        }
    }
}