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
            Assert.Equal(5, tryTimes);

            // Reset the try counter only when the test passes
            if (tryTimes == 5)
                tryTimes = 0;
            
        }
        [When]
        public void WhenITrySomething_P0_times(int n)
        {
            tryTimes++;
            Console.WriteLine("Tried " + tryTimes);
            Assert.Equal(n, tryTimes);

            // Reset the try counter only when the test passes
            if (tryTimes == n)
                tryTimes = 0;
        }

        [When]
        public void WhenIDoSomething()
        {
            Assert.True(true);
        }

        [Given(@"I will fail")]
        public void GivenIWillFail()
        {
            Assert.False(true);
        }

    }
}