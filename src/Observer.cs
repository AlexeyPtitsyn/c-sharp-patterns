/**
 * Observer pattern.
 * 
 * Observer pattern allows implement one-to-many dependency. If some object changes,
 * depending objects will be notified about that.
 */

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            FuelTank s = new FuelTank();

            s.Attach(new FuelTankObserver(s, "Onboard computer"));
            s.Attach(new FuelTankObserver(s, "Fuel sensor"));
            s.Attach(new FuelTankObserver(s, "...and one another electronic thing"));

            s.SubjectState = "fuel depleted";
            s.Notify();
        }
    }

    public abstract class Subject
    {
        private List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach(Observer o in _observers)
            {
                o.Update();
            }
        }
    }

    public class FuelTank: Subject
    {
        private string _subjectState;

        public string SubjectState
        {
            get { return _subjectState; }
            set {
                _subjectState = value;
                Console.WriteLine("FuelTank suddenly discovered that {0}.", value);
            }
        }
    }

    public abstract class Observer
    {
        public abstract void Update();
    }

    public class FuelTankObserver: Observer
    {
        private string _name;
        private string _observerState;
        private FuelTank _subject;
        public FuelTank Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public FuelTankObserver(FuelTank subject, string name)
        {
            _subject = subject;
            _name = name;
        }

        public override void Update()
        {
            _observerState = _subject.SubjectState;
            Console.WriteLine("{0} knows that {1}.", _name, _observerState);
        }
    }
}
