/**
 * Composition example.
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
