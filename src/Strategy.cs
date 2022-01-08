/**
 * Strategy pattern.
 * 
 * The strategy pattern defines a family of interchangeable algorithms
 * to interact with some clients.
 */
using System;
using System.Collections.Generic;

namespace Strategy
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            SortedList cars = new SortedList();
            cars.Add("Car 2");
            cars.Add("Car 1");
            cars.Add("Car 3");

            cars.SetSortStrategy(new DownSort());
            cars.Sort();

            Console.WriteLine("----");

            cars.SetSortStrategy(new UpSort());
            cars.Sort();

        }
    }

    public class SortedList {
        private List<string> _list = new List<string>();
        private SortStrategy _strategy;

        public void SetSortStrategy(SortStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Add(string item)
        {
            _list.Add(item);
        }

        public void Sort()
        {
            _strategy.Sort(_list);

            foreach(string item in _list)
            {
                Console.WriteLine(item);
            }
        }
    }

    public abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    /**
     * Sort items from smallest to biggest.
     */
    public class DownSort: SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();
        }
    }

    /**
     * Sort items from biggest to smallest.
     */
    public class UpSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();
            list.Reverse();
        }
    }
}
