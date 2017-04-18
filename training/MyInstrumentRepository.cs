using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training
{
    public class MyInstrumentRepository : IInstrumentRepository
    {
       

        public List<Instrument> instruments;

        // Constructeur 
        public MyInstrumentRepository()
        {
            instruments = new List<Instrument>();
        }

        void IInstrumentRepository.AddInstrument(Instrument instrument)
        {
            if (instruments.Contains(instrument))
            {
                throw new InvalidOperationException();
            }
            else
            {
                instruments.Add(instrument);
            }
        }

     
        Instrument IInstrumentRepository.GetInstrument(string name)
        {
            for(int i = 0; i < instruments.Count; i++)
            {
                if(instruments[i].Name == name)
                {
                    return instruments[i];
                }
            }
            throw new InvalidOperationException();
        }

    
        IEnumerable<Instrument> IInstrumentRepository.GetInstruments()
        {
            IEnumerable<Instrument> instrumentsList = new List<Instrument>();
            return instruments;
        }

      
        void IInstrumentRepository.Init()
        {        
            for (int i = 0; i < 5000; i++)
            {
                string name1 = "bond_" + i.ToString();
                string name2 = "forex_" + i.ToString();
                instruments.Add(new Instrument(name1,InstrumentType.Bond));
                instruments.Add(new Instrument(name2, InstrumentType.Forex));
            }
        }
    }
}
