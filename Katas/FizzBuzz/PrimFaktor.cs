using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace FizzBuzz
{
    public class PrimFaktor
    {
        private static int entry;

        public static List<int> factor(int value)
        {
            List<int> factors = new List<int>();
            entry = 2;
            while (value > 1)
            {
                while (value % entry == 0)
                {
                    value /= entry;
                    factors.Add(entry);
                }

                entry++;
            }
            return factors;
        }
    }
}