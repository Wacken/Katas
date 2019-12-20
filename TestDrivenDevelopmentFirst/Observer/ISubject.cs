using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    interface ISubject
    {
        void registerObserver(IObserver observer);
        void unregisterObserver(IObserver observer);
        void notifyObservers();
    }
}
