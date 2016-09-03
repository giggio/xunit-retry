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
        [RetryFact(5)]
        public void Try5Times()
        {
            tryTimes++;
            Console.WriteLine("Tried " + tryTimes);
            Assert.Equal(5, tryTimes);
        }
        [RetryFact]
        public void TryDefaultTimes()
        {
            tryTimes++;
            Console.WriteLine("Tried " + tryTimes);
            Assert.Equal(3, tryTimes);
        }
    }
}