using System.Collections.Generic;
using System;

namespace training
{
    public interface IInstrumentRepository
    {
        void AddInstrument(Instrument instrument);

        Instrument GetInstrument(string name);

        IEnumerable<Instrument> GetInstruments();

        void Init();

        string getRandomInstrumentKey(Random rand);

        void PriceUpdate(string key, double price);
    }


}