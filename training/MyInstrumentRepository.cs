using System;
using System.Collections.Generic;

namespace training
{
    public class MyInstrumentRepository : IInstrumentRepository
    {
        private readonly Dictionary<string, Instrument> _instruments;

        // Constructeur 
        public MyInstrumentRepository()
        {
            _instruments = new Dictionary<string, Instrument>();
        }

        public int Size()
        {
            return _instruments.Count;
        }

        void IInstrumentRepository.AddInstrument(Instrument instrument)
        {
            if (_instruments.ContainsKey(instrument.Name))
            {
                throw new InvalidOperationException();
            }
            else
            {
                _instruments.Add(instrument.Name, instrument);
            }
        }

     
        Instrument IInstrumentRepository.GetInstrument(string name)
        {
            if (_instruments.ContainsKey(name))
            {
                return _instruments[name];
            }

            throw new InvalidOperationException();
        }

    
        IEnumerable<Instrument> IInstrumentRepository.GetInstruments()
        {
            return _instruments.Values;
        }

      
        void IInstrumentRepository.Init()
        {        
            for (int i = 0; i < 5000; i++)
            {
                string name1 = "bond_" + i;
                string name2 = "forex_" + i;
                _instruments.Add(name1, new Instrument(name1,InstrumentType.Bond));
                _instruments.Add(name2, new Instrument(name2, InstrumentType.Forex));
            }
        }

        void IInstrumentRepository.InitWithPrices(int numberOfPrices)
        {        
             string name = "bond";
             _instruments.Add(name, new Instrument(name, InstrumentType.Bond));
             for (int j = 0; j < numberOfPrices; j++)
             {
                _instruments[name].Prices.Push(j);
             }          
        }

        // Met à jour le prix de l'instrument de nom "key" dans le repository
        void IInstrumentRepository.PriceUpdate(string key, double price)
        {
            _instruments[key].Prices.Push(price);
            Console.WriteLine($"{key} Price updated : {price}");
        }

        double IInstrumentRepository.GetMeanPrice(string key, int n)
        {
            return _instruments[key].ComputeMeanPrices(n);           
        }
    }
}
