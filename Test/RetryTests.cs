using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private int memberCalls = 0;

        static int tryTimes = 0;
        
        [RetryFact]
        public void ConstructorCalledForEachRetry()
        {
            tryTimes++;
            memberCalls++;
            Assert.Equal(1, memberCalls);
            Assert.Equal(3, tryTimes);
        }
    }

    public class NoRetriesFixture
    {       
        [Fact]
        public void ARegularTestMethodStillWorks()
        {
            Assert.True(true);
        }
    }

    public class Try5TimesFixture
    {
        static int tryTimes = 0;

        [RetryFact(MaxRetries = 5)]
        public void Try5Times()
        {
            tryTimes++;
            Console.WriteLine("Tried " + tryTimes);
            Assert.Equal(5, tryTimes);
        }
    }

    public class TryDefaultTimesFixture
    {
        static int tryTimes = 0;

        [RetryFact]
        public void TryDefaultTimes()
        {
            tryTimes++;
            Console.WriteLine("Tried " + tryTimes);
            Assert.Equal(3, tryTimes);
        }
    }
}