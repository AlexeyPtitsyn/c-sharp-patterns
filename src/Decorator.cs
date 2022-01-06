/**
 * Decorator pattern.
 * 
 * Decorator allows to add extra functionality to an existing object.
 */
using System;

namespace Decorator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Car c = new Truck();
            RustyTruckDecorator d = new RustyTruckDecorator();
            d.SetComponent(c);

            c.Run();
            Console.WriteLine("----");
            d.Run();
        }
    }

    public abstract class Car
    {
        public abstract void Run();
    }

    public class Truck: Car
    {
        public override void Run()
        {
            Console.WriteLine("Truck engine is started.");
        }
    }

    public abstract class Decorator: Car
    {
        protected Car _component;
        public void SetComponent(Car comp)
        {
            _component = comp;
        }

        public override void Run()
        {
            if (_component != null)
            {
                _component.Run();
            }
        }
    }

    public class RustyTruckDecorator: Decorator
    {
        public override void Run()
        {
            Console.WriteLine("Engine start failed...");
            Console.WriteLine("Engine start failed...");
            base.Run();
        }
    }
}
