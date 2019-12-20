using NUnit.Framework;

namespace NunitUdemy
{
    using System.Collections.Generic;

    [TestFixture]
    public class RomanNumeralsTest
    {
        [TestCase(1,"I")]
        [TestCase(2,"II")]
        [TestCase(4,"IV")]
        [TestCase(5,"V")]
        [TestCase(10,"X")]
        [TestCase(14,"XIV")]
        public void ParseNumerals(int expected, string romanNumeral)
        {
            Assert.AreEqual(expected,Roman.Parse(romanNumeral));
        }
    }

    public class Roman
    {
        private static readonly Dictionary<char,int> map = new Dictionary<char, int>()
        {
            {'I',1},
            {'V',5},
            {'X',10}
        };
        public static int Parse(string roman)
        {
            int output = 0;
            for (int index = 0; index < roman.Length; index++)
            {
                if (index + 1 < roman.Length && isSubtractive(roman[index], roman[index+1]))
                    output -= map[roman[index]];
                else
                    output += map[roman[index]];
            }
            return output;
        }

        private static bool isSubtractive(char c1, char c2)
        {
            return map[c1] < map[c2];
        }
    }
}