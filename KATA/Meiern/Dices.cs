namespace Meiern
{
    public interface IDices
    {
        int throwDices();
    }

    public class Dices : IDices
    {
        private Die dice;
        public Dices(Die die)
        {
            dice = die;
        }

        public int throwDices()
        {
            int first = dice.throws();
            int second = dice.throws();
            return first <= second ? second * 10 + first : first * 10 + second;
        }
    }
}