using System;
using System.Linq;
using System.Timers;

namespace training
{
    public class Pricer
    {
        private readonly Timer _timer;
        private readonly IInstrumentRepository _instrumentRepository;
        private readonly string[] _instruments;
        private readonly Random _rand;

        public Pricer(IInstrumentRepository instrumentRepository, double interval)
        {
            _timer = new Timer(interval);
            _instrumentRepository = instrumentRepository;
            _instruments= _instrumentRepository.GetInstruments().Select(instrument => instrument.Name).ToArray();
            _rand = new Random((int)DateTime.Now.Ticks);
        }
        
        public void Price()
        {                      
            _timer.Elapsed +=  OnTimedEvent;
            _timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // Choix aléatoire d'un instrument dans le repository
            string randomKey = GetRandomInstrumentKey(_rand);
            double randPrice = 100.0 * _rand.NextDouble();
            _instrumentRepository.PriceUpdate(randomKey, randPrice);
        }

        private string GetRandomInstrumentKey(Random rand)
        {
            int size = _instruments.Length;
            if (size == 0)
            {
                throw new InvalidOperationException();
            }
            return _instruments[rand.Next(size)];
        }
    }
}
