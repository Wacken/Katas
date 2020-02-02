using System;

namespace Meiern
{
    public class Dice : Die
    {
        public int throws()
        {
            Random random = new Random();
            return random.Next(1, 6);
        }
    }

    public interface Die
    {
        int throws();
    }
}