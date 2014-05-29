using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            Assert.Equal(1, 2 - 1);
        }
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
}