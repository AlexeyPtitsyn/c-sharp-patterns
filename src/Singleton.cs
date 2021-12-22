/**
 * Singleton example.
 *
 * Singleton is used to guarantee that class has only one instance.
 * Also, singleton provides access to this instance.
 */
namespace Program
{
    class Singleton
    {
        private static Singleton? _instance;
        public int Counter; // Instance variable

        // Make constructor private, so no-one can construct it.
        private Singleton() { }

        // Instance method
        public void AddCounter()
        {
            Counter++;
        }

        // Get singleton instance
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }

    public class Program
    {
        public static void Main()
        {
                Console.WriteLine(Singleton.GetInstance().Counter); // 0
                Singleton.GetInstance().AddCounter();
                Console.WriteLine(Singleton.GetInstance().Counter); // 1
        }
    }
}
