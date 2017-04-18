using System;
using System.Collections.Generic;

namespace training
{
    public class MyInstrumentRepository : IInstrumentRepository
    {
        private Dictionary<string, Instrument> instruments;

        // Constructeur 
        public MyInstrumentRepository()
        {
            instruments = new Dictionary<string, Instrument>();
        }

        void IInstrumentRepository.AddInstrument(Instrument instrument)
        {
            if (instruments.ContainsKey(instrument.Name))
            {
                throw new InvalidOperationException();
            }
            else
            {
                instruments.Add(instrument.Name, instrument);
            }
        }

     
        Instrument IInstrumentRepository.GetInstrument(string name)
        {
            if (instruments.ContainsKey(name))
            {
                return instruments[name];
            }

            throw new InvalidOperationException();
        }

    
        IEnumerable<Instrument> IInstrumentRepository.GetInstruments()
        {
            return instruments.Values;
        }

      
        void IInstrumentRepository.Init()
        {        
            for (int i = 0; i < 5000; i++)
            {
                string name1 = "bond_" + i.ToString();
                string name2 = "forex_" + i.ToString();
                instruments.Add(name1, new Instrument(name1,InstrumentType.Bond));
                instruments.Add(name2, new Instrument(name2, InstrumentType.Forex));
            }
        }
    }
}
