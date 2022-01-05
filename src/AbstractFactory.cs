/**
 * Abstract factory example.
 * 
 * Abstract factory allows to create related objects without specifying their
 * concrete class.
 */

using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            AbstractFactory factory = new PassengerCarFactory();
            AbstractFactory truckFactory = new TruckFactory();

            List<Car> carList = new List<Car>();

            // Let's create three cars...
            for(int i = 0; i < 3; i++)
            {
                carList.Add(factory.CreateAbstractCar());
            }

            // ...and two trucks:
            for (int i = 0; i < 2; i++)
            {
                carList.Add(truckFactory.CreateAbstractCar());
            }

            // Run each one:
            foreach (var carItem in carList)
            {
                carItem.Identify();
            }
        }
    }

    /**
     * Abstract "car".
     */
    abstract class Car
    {
        protected string _name;
        protected string _type;

        public void Identify()
        {
            Console.WriteLine($"{_type} - {_name}");
        }
    }

    /**
     * A passenger kind of car.
     */
    class PassengerCar: Car
    {
        public PassengerCar(string name)
        {
            _name = name;
            _type = "PassengerCar";
        }
    }

    /**
     * A truck kind of car.
     */
    class Truck: Car
    {
        public Truck(string name)
        {
            _name = name;
            _type = "Truck";
        }
    }

    /**
     * Simple factory.
     */
    abstract class AbstractFactory
    {
        protected int _number;
        public abstract Car CreateAbstractCar();
    }

    /**
     * Small factory.
     */
    class PassengerCarFactory: AbstractFactory
    {
        public override Car CreateAbstractCar()
        {
            _number++;
            return new PassengerCar($"A car from passenger car factory No {_number}");
        }
    }

    /**
     * Truck factory.
     */
    class TruckFactory: AbstractFactory
    {
        public override Car CreateAbstractCar()
        {
            _number++;
            return new Truck($"A car from truck factory {_number}");
        }
    }
}
