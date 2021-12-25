/**
 * Association pattern example.
 * 
 * Association is a general type of association-like patterns.
 * 
 *     Association:
 *     public class One {
 *       void Fun(Two two) {
 *         // ...
 *       }
 *     }
 *
 *     Aggregation:
 *     public class One {
 *       private Two _two;
 *       void Fun(Two two) {
 *         _two = two;
 *       }
 *     }
 *
 *     Composition:
 *     public class One {
 *       private Two _two;
 *       void Fun() {
 *         _two = new Two();
 *       }
 *     }
 */

using System;

namespace Association
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Car truck = new Truck();

            Auto.MoveCar(truck);

            Console.WriteLine($"Truck velocity is: {truck.Velocity}");
        }
    }

    /**
     * A typical car
     */
    interface Car
    {
        string Name { get; set; }
        int Velocity { get; set; }
    }

    /**
     * Truck is a kind of car
     */
    class Truck: Car
    {
        public string Name { get; set;  }
        public int Velocity { get; set; }

        public Truck()
        {
            Name = "Truck";
            Velocity = 0;
        }
    }

    /**
     * Auto class with association.
     */
    class Auto
    {
        public static void MoveCar(Car car) {
            car.Velocity += 1;
        }
    }
}
