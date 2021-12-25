/**
 * Factory method example.
 * 
 * Factory allows class to create objects. Which one of the objects is should
 * be defined in another class.
 */

using System;

namespace FactoryMethod
{
    /**
     * Test of factory.
     */
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Let's create some cars.
            CarCreator _creator;
            for(int i = 0; i < 10; i++)
            {
                _creator = new PassengerCarCreator();
                // Even numbers will be a passenger cars. Odd - trucks.
                if(i % 2 == 0)
                {
                    _creator = new TruckCreator();
                }

                Car _car = _creator.FactoryMethod();

                Console.WriteLine(_car.Name);
            }
        }
    }

    /**
     * Car interface.
     */
    interface Car
    {
        string Name { get; set; }
    }

    /**
     * Small car class
     */
    class PassengerCar: Car
    {
        public string Name { get; set; }

        public PassengerCar()
        {
            Name = "Passenger car.";
        }
    }

    /**
     * Truck car
     */
    class Truck: Car
    {
        public string Name { get; set; }

        public Truck ()
        {
            Name = "Truck.";
        }
    }

    /**
     * Abstract Car creator.
     */
    abstract class CarCreator
    {
        public abstract Car FactoryMethod();
    }

    /**
     * Truck creator
     */
    class TruckCreator: CarCreator
    {
        public override Car FactoryMethod()
        {
            return new Truck();
        }
    }

    /**
     * Passenger car creator
     */
    class PassengerCarCreator: CarCreator
    {
        public override Car FactoryMethod()
        {
            return new PassengerCar();
        }
    }
}
