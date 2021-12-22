/**
 * Composition example.
 *
 * Composition is a specific type of aggregation, that implies ownership
 * of the object.
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
namespace Program
{
    // Runnable cars should have velocity.
    public interface IRunnable
    {
        int Velocity { get; set; }
    }

    // A typical acceleration of runnable car.
    public class AccelerateBehavior
    {
        public IRunnable vehicle;
        public AccelerateBehavior(IRunnable vehicle)
        {
            this.vehicle = vehicle;
        }
        public void Run(int acceleration)
        {
            this.vehicle.Velocity += acceleration;
        }
    }

    // Well, this is, actually, a car.
    public class Car: IRunnable
    {
        public int Velocity { get; set; }
        public Car(int velocity)
        {
            this.Velocity = velocity;
        }
        public void Accelerate(int value) {
            AccelerateBehavior _ab = new AccelerateBehavior(this);
            _ab.Run(value);
        }
    }

    // Test of car.
    public class Program
    {
        public static void Main()
        {
            Car car = new Car(10);
            Console.WriteLine("Car velocity before acceleration: " + car.Velocity); // 10
            car.Accelerate(10);
            Console.WriteLine("Car velocity after acceleration: " + car.Velocity); // 20
        }
    }
}
