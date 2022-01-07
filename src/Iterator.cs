/**
 * Iterator pattern.
 * 
 * Iterator pattern provides an effect way to agregate objects sequentially
 * without exposing their underlying implementation.
 */
using System;
using System.Collections.Generic;

namespace Iterator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CarAggregate cars = new CarAggregate();
            cars[0] = "Car one";
            cars[1] = "Car two";
            cars[2] = "Car three";

            // Iterate through the collection:
            Iterator iter = cars.CreateIterator();
            object item = iter.First();

            while (item != null)
            {
                Console.WriteLine($"Car: {item}");
                item = iter.Next();
            }
        }
    }

    /**
     * Aggregate abstract class.
     */
    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    /**
     * Aggregate concrete class.
     */
    public class CarAggregate: Aggregate
    {
        List<object> _items = new List<object>();
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public object this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                _items.Insert(index, value);
            }
        }

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
    }

    /**
     * Abstract iterator.
     */
    public abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    /**
     * Concrete iterator.
     */
    public class ConcreteIterator: Iterator
    {
        CarAggregate _aggregate;
        int _current = 0;

        public ConcreteIterator(CarAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        
        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        public override object First()
        {
            return _aggregate[0];
        }

        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }

        public override object Next()
        {
            object ret = null;

            if(_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }
    }
}
