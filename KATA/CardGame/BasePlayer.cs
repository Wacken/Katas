using System;
using System.Collections.Generic;
using CardGame.UnitTest;

namespace CardGame
{
    public interface Player
    {
        void draw();
        void refresh();
        void playCard(Card card);
        int getLife();
        event Action<int, int> DoDamage;
    }

    public class BasePlayer : Player
    {
        private static int playerID = 0;
        public readonly int playerNumber;
        private readonly ManaPool manaPool;
        private readonly Game game;
        
        #region Random

        private readonly RandomGenerator randomGenerator;
        
        
        private class DefaultRandom : RandomGenerator
        {
            public int Generate(int max)
            {
                return (new Random()).Next(max);
            }
        }

        #endregion

        internal BasePlayer(RandomGenerator generator = null ,ManaPool pool = null, Game theGame = null)
        {
            randomGenerator = generator ?? new DefaultRandom();
            manaPool = pool ?? new ManaPoolBase();
            game = theGame ?? new StandardGame();
            DoDamage += takeDamage;
            playerNumber = playerID++;
        }

        public List<Card> hand = new List<Card>();
        public List<Card> deck = new List<Card>();
        private int lifeCount = MaxLife;
        public static int MaxLife = 30;

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
            if (DoDamage != null) DoDamage(card.ManaCost,this.playerNumber);
            //game.getOpponent().takeDamage(card.ManaCost,this.playerNumber);
        }

        public void takeDamage(int amount,int playerNumber)
        {
            if(playerNumber != this.playerNumber)
                lifeCount-=amount;
        }

        public int getLife()
        {
            return lifeCount;
        }

        public event Action<int,int> DoDamage;
    }
}