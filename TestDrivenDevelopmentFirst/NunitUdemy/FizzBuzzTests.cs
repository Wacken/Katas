using NUnit.Framework;

namespace NunitUdemy
{
    using System.Linq;
    using System.Text;

    [TestFixture]
    public class FizzBuzzTests
    {
        [TestCase("Fizz",3)]
        [TestCase("Fizz",6)]
        [TestCase("Buzz",5)]
        [TestCase("Buzz",10)]
        [TestCase("",7)]
        [TestCase("FizzBuzz",15)]
        [TestCase("FizzBuzz",30)]
        public void TestFizzBuzz(string expected, int index)
        {
            Assert.AreEqual(expected,fizzBuzz(index));
        }

        private string fizzBuzz(int index)
        {
            StringBuilder output = new StringBuilder("");
            if(index % 3 == 0)
                output.Append("Fizz");
            if (index % 5 == 0)
                output.Append("Buzz");
            return output.ToString();
        }
    }
}