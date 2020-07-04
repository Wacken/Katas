using System;
using System.Runtime.Versioning;
using NUnit.Framework;

namespace BunnyTest
{
    [TestFixture]
    public class BunnyPopulizer
    {
        private Populizer populizer;

        [SetUp]
        public void setup()
        {
            populizer = new Populizer();
        }
        
        [TestCase(1,1)]
        [TestCase(2,2)]
        [TestCase(3,4)]
        [TestCase(4,7)]
        [TestCase(5,13)]
        [TestCase(6,24)]
        [TestCase(7,44)]
        public void createBunnies_GivenMonth_ReturnsExpected(int month, int expected)
        {
            Assert.AreEqual(expected,populizer.createBunnies(month), "Total");
        }

        [TestCase(1, 1)]
        [TestCase(2,1)]
        [TestCase(3,2)]
        [TestCase(4,4)]
        [TestCase(5,7)]
        public void createBunnies_GivenMonth_Generation1Is(int month, int generation1)
        {
            populizer.createBunnies(month);
            Assert.AreEqual(generation1, populizer.Generation1);
        }

        [TestCase(2, 1)]
        [TestCase(3,1)]
        [TestCase(4,2)]
        [TestCase(5,4)]
        public void createBunnies_GivenMonth_Generation2Is(int month, int generation2)
        {
            populizer.createBunnies(month);
            Assert.AreEqual(generation2, populizer.Generation2);
        }
        
        [TestCase(3, 1)]
        [TestCase(4,1)]
        [TestCase(5,2)]
        public void createBunnies_GivenMonth_Generation3Is(int month, int generation3)
        {
            populizer.createBunnies(month);
            Assert.AreEqual(generation3, populizer.Generation3);
        }

        [TestCase(1,1)]
        [TestCase(2,2)]
        [TestCase(3,6)]
        [TestCase(4,13)]
        [TestCase(5,42)]
        public void createBunniesTriple_GivenMonth_ReturnsExpected(int month, int expected)
        {
            Assert.AreEqual(expected,populizer.createBunniesTriple(month));
        }
    }

    public class Populizer
    {
        public int createBunnies(int month)
        {
            int generation1 = 1;
            int generation2 = 0;
            int generation3 = 0;
            if (month >= 2)
            {
                generation1 = createBunnies(month - 1);
                generation2 = createBunnies(month - 2);
            }
            if (month >= 3)
                generation3 = createBunnies(month -3);
            Generation1 = generation1;
            Generation2 = generation2;
            Generation3 = generation3;
            return Generation1 + Generation2 + Generation3;
        }
        // public int createBunnies(int month)
        // {
        //     int died = 0;
        //     int i = month;
        //     while (i > 3)
        //     {
        //         died += createBunnies(i - 3) + (createBunnies(i-3) - (int)Math.Pow(2,i-3-1)) ;
        //         i--;
        //     }
        //     return (int) Math.Pow(2,month-1) - died;
        // }

        public int Generation1 { get; set; }
        public int Generation2 { get; set; }
        public int Generation3 { get; set; }

        public int createBunniesTriple(int month)
        {
            int generation1 = 1;
            int generation2 = 0;
            int generation3 = 0;
            if (month >= 2)
                generation1 = createBunniesTriple(month - 1);
            if (month >= 3)
                generation2 = createBunniesTriple(month - 2) * 3;
            else if(month >= 2)
                generation2 = 1;
            if (month >= 3)
                generation3 = createBunniesTriple(month -3);
            Generation1 = generation1;
            Generation2 = generation2;
            Generation3 = generation3;
            return Generation1 + Generation2 + Generation3;
        }
    }
}