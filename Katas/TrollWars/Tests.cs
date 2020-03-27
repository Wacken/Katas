using System;
using System.Linq;
using NUnit.Framework;
using Enumerable = System.Linq.Enumerable;

namespace TrollWars
{
    [TestFixture]
    public class DisemvowelTest
    {
        [Test]
        [Ignore("Acceptance")]
        public void ShouldRemoveAllVowels()
        {
            Assert.AreEqual("Ths wbst s fr lsrs LL!", Kata.Disemvowel("This website is for losers LOL!"));
        }

        [TestCase("th!")]
        [TestCase("")]
        public void Disemvowel_NoVowles_Input(string input)
        {
            Assert.AreEqual(input, Kata.Disemvowel(input));
        }

        [TestCase("a")]
        [TestCase("i")]
        [TestCase("u")]
        [TestCase("e")]
        [TestCase("o")]
        [TestCase("A")]
        [TestCase("aa")]
        [TestCase("aioeuAIOEUaOeUi")]
        public void Disemvowel_OnlyVowel_empty(string input)
        {
            Assert.AreEqual("", Kata.Disemvowel(input));
        }
    }
}