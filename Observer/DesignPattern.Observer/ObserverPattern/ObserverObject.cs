using DesignPattern.Observer.DAL;

namespace DesignPattern.Observer.ObserverPattern
{
    public class ObserverObject
    {
        private readonly List<IObserver> _observers;
        public ObserverObject()
        {
            _observers = new List<IObserver>();
        }

        public void Attach(IObserver observer) //subscribe
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer) //unsubscribe
        {
            _observers.Remove(observer);
        }

        public void Notify(AppUser appUser) //notify
        {
            foreach (var observer in _observers)
            {
                observer.CreateNewUser(appUser);
            }
        }
    }
}
