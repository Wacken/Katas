using System;

namespace CardGame
{
    public interface ManaPool
    {
        void use(int amount);
        void extend();
        void refill();
    }

    public class ManaPoolBase : ManaPool
    {
        internal int Content { get; private set; }
        internal int Capacity { get; private set; }

        public void use(int amount)
        {
            if (Content - amount < 0)
                throw new NotEnoughMana();
            Content -= amount;
        }

        public void extend()
        {
            if(Capacity == 10)
                return;
            Capacity++;
            Content++;
        }

        public class NotEnoughMana : Exception
        {
        }

        public void refill()
        {
            Content = Capacity;
        }
    }
}