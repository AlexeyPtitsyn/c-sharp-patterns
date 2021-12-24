/**
 * Aggregation pattern example.
 * 
 * Aggregation is a specific type of association, that allows to pass entity
 * of one class to another and set it as refence.
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
    /**
     * Test.
     */
    public class Program
    {
        public static void Main()
        {
            Car car = new Car();
            string result = car.Accelerate(100);
            Console.WriteLine(result);

            Console.WriteLine("Added engine.");

            car.AddEngine(new Engine());
            result = car.Accelerate(100);
            Console.WriteLine(result);
        }
    }

    /**
     * A car that can have engine.
     */
    public class Car
    {
        private Engine? _engine;
        
        public void AddEngine(Engine engine)
        {
            _engine = engine;
        }

        public string Accelerate(int force)
        {
            if(_engine == null)
            {
                return $"You're pressing gas pedal with {force} force. But it is useless since car has no engine.";
            }

            int result = _engine.IncreaseGas(force);

            return $"Car started to accelerate with the power of {result}.";
        }
    }

    /**
     * Engine that we should put in the car.
     */
    public class Engine
    {
        public int IncreaseGas(int throttle)
        {
            return throttle * 10;
        }
    }
}
