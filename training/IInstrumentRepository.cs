using System.Collections.Generic;

namespace training
{
    public interface IInstrumentRepository
    {
        void AddInstrument(Instrument instrument);

        Instrument GetInstrument(string name);

        IEnumerable<Instrument> GetInstruments();

        void Init();

        void InitWithPrices(int numberOfPrices);

        void PriceUpdate(string key, double price);

        double GetMeanPrice(string key, int n);
    }


}