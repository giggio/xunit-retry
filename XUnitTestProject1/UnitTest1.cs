using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            Assert.Equal(1, 2 - 1);
        }
        //[Fact]
        //public void TestMethod2()
        //{
        //    Assert.Equal(1, 2);
        //}
        [Fact]
        public void TestMethod3()
        {
            Assert.True(true);
            Console.WriteLine("Hello there");
        }
        static int tentou = 0;
        [Retry(5)]
        public void TentaAlgumasVezes()
        {
            tentou++;
            Console.WriteLine("Tentou " + tentou);
            Assert.True(tentou >= 5);
        }
    }
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
    class RetryAttribute : FactAttribute
    {
        readonly int times;

        public RetryAttribute(int times)
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
