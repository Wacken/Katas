using NUnit.Framework;

namespace FizzBuzz
{
    [TestFixture]
    public class FizzBuzzTest
    {
        [Test]
        public void Of0_is0()
        {
            Assert.AreEqual("0",FizzBuzzC.of(0));
        }

        [Test]
        public void Of1_is1()
        {
            Assert.AreEqual("1",FizzBuzzC.of(1));
        }

        [Test]
        public void Of3_isFizz()
        {
            Assert.AreEqual("Fizz",FizzBuzzC.of(3));
        }

        [Test]
        public void Of5_isBuzz()
        {
            Assert.AreEqual("Buzz",FizzBuzzC.of(5));
        }

        [Test]
        public void Of6_isFizz()
        {
            Assert.AreEqual("Fizz",FizzBuzzC.of(6));
        }

        [Test]
        public void Of10_isBuzz()
        {
            Assert.AreEqual("Buzz",FizzBuzzC.of(10));
        }

        [Test]
        public void Of15_isFizzBuzz()
        {
            Assert.AreEqual("FizzBuzz",FizzBuzzC.of(15));
        }

        [Test]
        public void OfHigh3_isFizz()
        {
            Assert.AreEqual("Fizz",FizzBuzzC.of(3*3*3*3));
        }
    }
}