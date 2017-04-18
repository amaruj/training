using System.Collections.Generic;

namespace training
{
    public interface IInstrumentRepository
    {
        void AddInstrument(Instrument instrument);

        Instrument GetInstrument(string name);

        IEnumerable<Instrument> GetInstruments();

        void Init();

        string getRandomInstrumentKey();

        void PriceUpdate(string key, double price);
    }


}