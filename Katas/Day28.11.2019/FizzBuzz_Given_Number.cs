using System;
using NUnit.Framework;

namespace Day28._11._2019
{
    [TestFixture]
    public class FizzBuzz_Given_Number
    {
        [TestCase(0)]
        [TestCase(1)]
        public void return_X_Given_Input_X(int number)
        {
            Assert.AreEqual(number.ToString(), FizzBuzz.fizzBuzz(number));
        }

        [TestCase(3)]
        [TestCase(6)]
        public void return_Fizz_Given_Input_Divisable_3(int number)
        {
            Assert.AreEqual("Fizz", FizzBuzz.fizzBuzz(number));
        }

        [TestCase(5)]
        [TestCase(10)]
        public void return_Fizz_Given_Input_Divisable_5(int number)
        {
            Assert.AreEqual("Buzz", FizzBuzz.fizzBuzz(number));
        }

        [TestCase(15)]
        public void return_FizzBuzz_Given_Input_Divisable_5_3(int number)
        {
            Assert.AreEqual("FizzBuzz", FizzBuzz.fizzBuzz(number));
        }
    }
}