using System;

namespace Doing
{
    public class Sum : Expression
    {
        public Expression _augend;
        public Expression _addend;

        public Sum(Expression augend, Expression addend)
        {
            this._augend = augend;
            this._addend = addend;
        }

        public Expression plus(Expression addend)
        {
            return new Sum(this, addend);
        }

        public Money reduce(Bank bank, string to)
        {
            int amount = bank.reduce(_augend, to).Amount + bank.reduce(_addend, to).Amount;
            return new Money(amount, to);
        }

        public Expression times(int multiplier)
        {
            return new Sum(_augend.times(multiplier), _addend.times(multiplier));
        }
    }
}