using Doing;
using System;
using Xunit;
namespace XUnitTest
{
    public class UnitTest
    {
        [Fact]
        public void testMultiplication()
        {
            Money five = Money.dollar(5);
            Assert.Equal(Money.dollar(10), five.times(2));
            Assert.Equal(Money.dollar(15), five.times(3));
        }

        [Fact]
        public void testEquality()
        {
            Assert.True(Money.dollar(5).Equals(Money.dollar(5)));
            Assert.False(Money.dollar(5).Equals(Money.dollar(6)));
            Assert.False(Money.franc(5).Equals(Money.dollar(5)));
        }

        [Fact]
        public void testCurrency()
        {
            Assert.Equal("USD", Money.dollar(1).Currency);
            Assert.Equal("CHF", Money.franc(1).Currency);
        }

        [Fact]
        public void testSimpleAddition()
        {
            Money five = Money.dollar(5);
            Expression sum = five.plus(five);
            Bank bank = new Bank();
            Money reduced = bank.reduce(sum, "USD");
            Assert.Equal(Money.dollar(10), reduced);
        }

        [Fact]
        public void testPlusReturnsSum()
        {
            Money five = Money.dollar(5);
            Expression result = five.plus(five);
            Sum sum = (Sum)result;
            Assert.Equal(five, sum._augend);
            Assert.Equal(five, sum._addend);
        }

        [Fact]
        public void testReduceSum()
        {
            Bank bank = new Bank();
            Expression sum = new Sum(Money.dollar(5), Money.dollar(4));
            Money reduced = bank.reduce(sum, "USD");
            Assert.Equal(Money.dollar(9), reduced);
        }

        [Fact]
        public void testReduceMoney()
        {
            Bank bank = new Bank();
            Money result = bank.reduce(Money.dollar(1), "USD");
            Assert.Equal(result, Money.dollar(1));
        }

        [Fact]
        public void testReduceMoneyDifferentCurrnency()
        {
            Bank bank = new Bank();
            bank.addRate("CHF", "USD", 2);
            Money result = bank.reduce(Money.franc(2), "USD");
            Assert.Equal(result, Money.dollar(1));
        }

        [Fact]
        public void testArrayEquals()
        {
            Assert.Equal(new Object[] { "abc", "cde" }, new Object[] { "abc", "cde" });
        }

        [Fact]
        public void testIdentityRate()
        {
            Assert.Equal(1, new Bank().rate("USD", "USD"));
        }

        [Fact]
        public void testMixedAddition()
        {
            Expression fiveBucks = Money.dollar(5);
            Expression tenFrancs = Money.franc(10);
            Bank bank = new Bank();
            bank.addRate("CHF", "USD", 2);
            Money result = bank.reduce(fiveBucks.plus(tenFrancs), "USD");
            Assert.Equal(result, Money.dollar(10));
        }

        [Fact]
        public void testSumPlusMoney()
        {
            Expression fiveBucks = Money.dollar(5);
            Expression tenFrancs = Money.franc(10);
            Bank bank = new Bank();
            bank.addRate("CHF", "USD", 2);
            Expression sum = new Sum(fiveBucks, tenFrancs).plus(fiveBucks);
            Money result = bank.reduce(sum, "USD");
            Assert.Equal(result, Money.dollar(15));
        }

        [Fact]
        public void testSumTimes()
        {
            Expression fiveBucks = Money.dollar(5);
            Expression tenFrancs = Money.franc(10);
            Bank bank = new Bank();
            bank.addRate("CHF", "USD", 2);
            Expression sum = new Sum(fiveBucks, tenFrancs).times(2);
            Money result = bank.reduce(sum, "USD");
            Assert.Equal(result, Money.dollar(20));
        }

    }
}
