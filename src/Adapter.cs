/**
 * Adapter example.
 * 
 * It converts one interface of the class into another.
 * Adapter pattern lets work classes with different
 * interfaces together.
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
            ClientInterface inter = new Adapter();
            Console.WriteLine(inter.Request("test"));
        }
    }

    /**
     * Client interface.
     */
    interface ClientInterface
    {
        public string Request(string str);
    }

    /**
     * Adapter itself.
     */
    public class Adapter: ClientInterface
    {
        private DB adaptee = new DB();

        public string Request(string str)
        {
            return adaptee.MakeRequest(str);
        }
    }

    /**
     * Existing interface.
     */
    public class DB
    {
        public string MakeRequest(string val)
        {
            return $"Response for {val}";
        }
    }
}
