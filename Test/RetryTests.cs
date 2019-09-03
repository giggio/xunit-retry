using System;
using Xunit;

namespace XUnitTestProject1
{
    public class NewInstanceUsedForEachTest_Fact
    {
        private int memberCalls = 0;

        static int tryTimes = 0;
        
        [Retry]
        public void ConstructorCalledForEachRetry_Fact()
        {
            tryTimes++;
            memberCalls++;
            Assert.Equal(1, memberCalls);
            Assert.Equal(3, tryTimes);
        }
    }

    public class NewInstanceUsedForEachTest_Theory
    {
        private int memberCalls = 0;

        static int tryTimes = 0;

        [RetryTheory]
        [InlineData(10)]
        public void ConstructorCalledForEachRetry_Theory(int i)
        {
            Assert.Equal(10, i);

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

        [Retry(MaxRetries = 5)]
        public void Try5Times_Fact()
        {
            tryTimes++;
            Console.WriteLine("Tried " + tryTimes);
            Assert.Equal(5, tryTimes);
        }

        [RetryTheory(MaxRetries = 5)]
        public void Try5Times_Theory(int i)
        {
            Assert.Equal(10, i);

            tryTimes++;
            Console.WriteLine("Tried " + tryTimes);
            Assert.Equal(5, tryTimes);
        }

    }

    public class TryDefaultTimesFixture
    {
        static int tryTimes = 0;

        [Retry]
        public void TryDefaultTimes_Fact()
        {
            tryTimes++;
            Console.WriteLine("Tried " + tryTimes);
            Assert.Equal(3, tryTimes);
        }

        [RetryTheory]
        public void TryDefaultTimes_Theory(int i)
        {
            Assert.Equal(10, i);

            tryTimes++;
            Console.WriteLine("Tried " + tryTimes);
            Assert.Equal(3, tryTimes);
        }
    }
}
