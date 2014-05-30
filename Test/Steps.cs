using System;
using TechTalk.SpecFlow;
using Xunit;
namespace XUnitTestProject1
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        static int tryTimes = 0;
        [When]
        public void WhenITrySomething()
        {
            tryTimes++;
            Console.WriteLine("Tried " + tryTimes);
            Assert.True(tryTimes == 5);
        }
        [When]
        public void WhenITrySomething_P0_times(int n)
        {
            tryTimes++;
            Console.WriteLine("Tried " + tryTimes);
            Assert.True(tryTimes == n);
        }
        [When]
        public void WhenIDoSomething()
        {
            Assert.True(true);
        }
        [AfterScenario]
        public void AfterScenario()
        {
            tryTimes = 0;
        }
    }
}