using System.Collections.Generic;

namespace training
{
    public interface IInstrumentRepository
    {
        void AddInstrument(Instrument instrument);

        Instrument GetInstrument(string name);

        IEnumerable<Instrument> GetInstruments();

        void Init(int numberOfInstrument);

        void CleanPrices();

        void PriceUpdate(string key, double price);
    }
}