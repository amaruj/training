using System;
using System.Collections.Generic;
using System.Linq;

namespace training
{
    public class Instrument
    {
        private readonly Stack<double> _prices;
        private const int NumberOfPrices = 5;

        public string Name { get; }

        public InstrumentType Type { get; }

        public double Price { get; private set; }

        public double MeanPrice => _prices.Any() ? _prices.Average() : 0;

        public Action PriceUpdated;
        
        public Instrument(string name, InstrumentType type)
        {
            Name = name;
            Type = type;
            _prices = new Stack<double>();
        }
        
        public void UpdatePrice(string key, double price)
        {
            Price = price;

            _prices.Push(price);

            if (_prices.Count > NumberOfPrices)
            {
                _prices.Pop();
            }

            PriceUpdated?.Invoke();
            Console.WriteLine($"{key} Price updated : {price} // Mean Price : {MeanPrice}");
        }
    }
}
