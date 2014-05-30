using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            tryTimes = 0;
        }
        [Fact]
        public void ARegularTestMethodStillWorks()
        {
            Assert.True(true);
        }
        static int tryTimes = 0;
        [Retry(5)]
        public void Try5Times()
        {
            tryTimes++;
            Console.WriteLine("Tried " + tryTimes);
            Assert.True(tryTimes == 5);
        }
        [Retry]
        public void TryDefaultTimes()
        {
            tryTimes++;
            Console.WriteLine("Tried " + tryTimes);
            Assert.True(tryTimes == 3);
        }
    }
}