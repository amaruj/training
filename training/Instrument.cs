using System.Collections.Generic;
using System.Linq;

namespace training
{
    public class Instrument
    {

        public string Name { get; }

        public InstrumentType Type { get; }

        public Stack<double> Prices; 

        public Instrument(string name, InstrumentType type)
        {
            Name = name;
            Type = type;
            Prices = new Stack<double>();
        }

        public double ComputeMeanPrices(int n)
        {
            int numberOfPrices = Prices.Count;
            if (numberOfPrices == 0)
            {
                return 0.0;
            }
            if (numberOfPrices >= n)
            {
                numberOfPrices = n;
            }
            var enumerable = Prices.Take(numberOfPrices);
            return enumerable.Average();           
        }
    }
}
