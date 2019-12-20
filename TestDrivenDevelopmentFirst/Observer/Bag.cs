using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Bag : ISubject
    {
        List<IObserver> _observers = new List<IObserver>();

        int _chips;
        public int Chips { get { return _chips; } }
        int _chocolate;
        public int Chocolate { get { return _chocolate; } }
        int _gummybears;
        public int Gummybears { get { return _gummybears; } }

        public void notifyObservers()
        {
            foreach(IObserver observer in _observers)
            {
                observer.update(this);
            }
        }

        public void setValues(int chips, int chocolate, int gummybears)
        {
            _chips = chips;
            _chocolate = chocolate;
            _gummybears = gummybears;
            notifyObservers();
        }

        public void registerObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void unregisterObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
    }
}
