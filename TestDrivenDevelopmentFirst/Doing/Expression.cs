namespace Doing
{
    public interface Expression
    {
        Money reduce(Bank bank, string to);
        Expression plus(Expression tenFrancs);
        Expression times(int multiplier);
    }
}