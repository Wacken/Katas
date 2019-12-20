using System;
using System.Collections;

namespace Doing
{
    public class Bank
    {
        private Hashtable rates = new Hashtable();

        public Money reduce(Expression source, string to)
        {
            return source.reduce(this, to);
        }

        public void addRate(string from, string to, int rate)
        {
            rates.Add(new Pair(from, to), rate);
        }

        public int rate(string from, string to)
        {
            if (from.Equals(to))
                return 1;
            int rate = (int)rates[new Pair(from, to)];
            return rate;
        }

        private class Pair
        {
            private String from;
            private String to;

            public Pair(String from, String to)
            {
                this.from = from;
                this.to = to;
            }

            public override bool Equals(Object obj)
            {
                Pair pair = (Pair)obj;
                return from == pair.from && to == pair.to;
            }

            public override int GetHashCode()
            {
                return 0;
            }
        }
    }
}