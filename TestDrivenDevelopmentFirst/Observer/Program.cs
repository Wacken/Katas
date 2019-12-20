using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Bag bag = new Bag();
            bag.setValues(2, 3, 4);
            ChipsBag chips = new ChipsBag(bag);
            ChocolateBar chocolate = new ChocolateBar(bag);
            Gummybears gummybears = new Gummybears(bag);
            bag.setValues(4, 3, 2);
            Console.WriteLine($"Chips Count: {chips._chips},\nChoclate Count {chocolate._chocolate},\nGummyBears Count{gummybears._gummybears}");
            bag.unregisterObserver(chocolate);
            bag.setValues(5, 5, 5);
            Console.WriteLine($"Chips Count: {chips._chips},\nChoclate Count {chocolate._chocolate},\nGummyBears Count{gummybears._gummybears}");
            Console.ReadKey();
        }
    }
}
