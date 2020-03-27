using NUnit.Framework;

namespace FizzBuzz
{
    [TestFixture]
    public class PrimFaktorTest
    {
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        public void factorOfXPrime_isX(int expected)
        {
            Assert.AreEqual(new int[]{expected},PrimFaktor.factor(expected));
        }
        
        [Test]
        public void factorOf4_is2a2()
        {
            Assert.AreEqual(new int[]{2,2},PrimFaktor.factor(4));
        }

        [Test]
        public void factorOf6_is2a3()
        {
            Assert.AreEqual(new int[]{2,3},PrimFaktor.factor(6));
        }
        
        [Test]
        public void factorOf8_is2a2a2()
        {
            Assert.AreEqual(new int[]{2,2,2}, PrimFaktor.factor(8));
        }

        [Test]
        public void factorOf9_is3a3()
        {
            Assert.AreEqual(new int[]{3,3},PrimFaktor.factor(9));
        }

        [Test]
        public void factorof10_is2a5()
        {
            Assert.AreEqual(new int[]{2,5},PrimFaktor.factor(10));
        }

        [Test]
        public void factorofc_iscorrect()
        {
            Assert.AreEqual(new int[]{2,3,3,5,7,13,13},
                PrimFaktor.factor(2*3*3*5*7*13*13));
        }
    }
}