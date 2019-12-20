using System;
using System.Collections.Generic;
using CardGame.UnitTest;

namespace CardGame
{
    public class BasePlayer
    {
        #region Random

        private readonly RandomGenerator randomGenerator;
        private readonly ManaPool manaPool;
        
        private class DefaultRandom : RandomGenerator
        {
            public int Generate(int max)
            {
                return (new Random()).Next(max);
            }
        }

        #endregion

        internal BasePlayer(RandomGenerator generator ,ManaPool pool)
        {
            randomGenerator = generator ?? new DefaultRandom();
            manaPool = pool ?? new ManaPoolBase();
        }

        public List<Card> hand = new List<Card>();
        public List<Card> deck = new List<Card>();

        public void draw()
        {
            if(deck.Count == 0)
                return;
            int index = randomGenerator.Generate(deck.Count);
            hand.Add(deck[index]);
            deck.RemoveAt(index);
        }

        public void refresh()
        {
            manaPool.extend();
            manaPool.refill();
        }

        public void playCard(Card card)
        {
            hand.Remove(card);
            manaPool.use(card.ManaCost);
        }
    }
}