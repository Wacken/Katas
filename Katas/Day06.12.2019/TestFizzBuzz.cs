using System;
using NUnit.Framework;

namespace Day06._12._2019
{
    [TestFixture]
    public class TestFizzBuzz
    {
        private FizzBuzz fizzBuzz;

        public TestFizzBuzz()
        {
            fizzBuzz = new FizzBuzz();
        }

        [TestFixture]
        public class GivenPositiveNumber : TestFizzBuzz
        {

            [TestCase(1)]
            [TestCase(2)]
            public void returnX_GivenInt(int x)
            {
                Assert.AreEqual(x.ToString(), fizzBuzz.execute(x));
            }

            [TestCase(3)]
            [TestCase(6)]
            public void returnFizz_Given3(int input)
            {
                Assert.AreEqual("Fizz", fizzBuzz.execute(input));
            }

            [TestCase(5)]
            [TestCase(10)]
            public void returnBuzz_Given5(int input)
            {
                Assert.AreEqual("Buzz", fizzBuzz.execute(input));
            }

            [TestCase(15)]
            [TestCase(30)]
            public void returnFizzBuzz_Given15(int input)
            {
                Assert.AreEqual("FizzBuzz", fizzBuzz.execute(input));
            }
        }

        [TestFixture]
        public class Given0 : TestFizzBuzz
        {
            [Test]
            public void Return0_Given0()
            {
                Assert.AreEqual("0", fizzBuzz.execute(0));
            }
        }
        
        [TestFixture]
        public class GivenNegative : TestFizzBuzz
        {
            [Test]
            public void ReturnX_GivenNumber()
            {
                Assert.AreEqual("-1",fizzBuzz.execute(-1));
            }

            [Test]
            public void ReturnFizz_Givenneg3()
            {
                Assert.AreEqual("Fizz",fizzBuzz.execute(-3));
            }
        }
    }

    public class FizzBuzz
    {
        public string execute(int input)
        {
            string result = string.Empty;
            if (input == 0)
                return "0";
            if (input % 3 == 0)
                result += "Fizz";
            if (input % 5 == 0)
                result += "Buzz";
            return result.Equals(string.Empty) ? input.ToString() : result;
        }
    }
}