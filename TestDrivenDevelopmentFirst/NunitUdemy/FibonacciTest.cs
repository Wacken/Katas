using System;
using NUnit.Framework;

namespace NunitUdemy
{
    [TestFixture]
    public class FibonacciTest
    {
        [TestCase(0,0)]
        [TestCase(1,1)]
        [TestCase(1,2)]
        [TestCase(2,3)]
        [TestCase(3,4)]
        public void TestFibonacci(int expected, int index)
        {
            Assert.AreEqual(expected,getFibonacci(index));
        }

        private int getFibonacci(int index)
        {
            if (index == 0)
                return 0;
            else if (index == 1 || index == 2)
                return 1;
            else
                return getFibonacci(index-1) + getFibonacci(index-2);
            
        }
    }
}