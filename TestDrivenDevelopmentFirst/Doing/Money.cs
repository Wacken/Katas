namespace Doing
{
    using System;
    using System.Collections.Generic;

    public class Money : Expression
    {
        int _amount;
        public int Amount { get => this._amount; private set => this._amount = value; }
        string _currency;
        public string Currency { get => this._currency; private set => this._currency = value; }

        public Money(int amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override bool Equals(Object obj)
        {
            Money money = (Money)obj;
            return Amount == money.Amount 
                && Currency.Equals(money.Currency);
        }

        public static Money dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public Expression times(int multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }

        public Expression plus(Expression addend)
        {
            return new Sum(this, addend);
        }

        public override string ToString()
        {
            return Amount + " " + Currency;
        }

        public Money reduce(Bank bank, string to)
        {
            int rate = bank.rate(Currency, to);
            return new Money(Amount/rate,to);
        }
    }
}
