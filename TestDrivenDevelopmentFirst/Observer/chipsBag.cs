using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class ChipsBag : IObserver
    {
        ISubject _subject;
        public int _chips;
        public ChipsBag(ISubject subject)
        {
            _subject = subject;
            _subject.registerObserver(this);
        }

        public void update(Object o)
        {
            if(o is Bag)
            {
                _chips = (o as Bag).Chips;
            }
        }
    }

    class ChocolateBar : IObserver
    {
        public int _chocolate;

        ISubject _subject;
        public ChocolateBar(ISubject subject)
        {
            _subject = subject;
            _subject.registerObserver(this);
        }

        public void update(Object o)
        {
            if (o is Bag)
            {
                _chocolate = (o as Bag).Chocolate;
            }
        }
    }

    class Gummybears : IObserver
    {
        public int _gummybears;

        ISubject _subject;
        public Gummybears(ISubject subject)
        {
            _subject = subject;
            _subject.registerObserver(this);
        }

        public void update(Object o)
        {
            if (o is Bag)
            {
                _gummybears = (o as Bag).Gummybears;
            }
        }
    }
}
