using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace training
{
    public class Pricer
    {
        System.Timers.Timer timer;
        IInstrumentRepository ir;
        Random rand;

        public Pricer(IInstrumentRepository ir, double interval, Random rand)
        {
            timer = new Timer(interval);
            this.ir = ir;
            this.rand = rand;
        }
        
        public void price()
        {                      
            timer.Elapsed +=  OnTimedEvent;
            timer.Enabled = true;
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // Choix aléatoire d'un instrument dans le repository
            string randomKey = ir.getRandomInstrumentKey(rand);
            double randPrice = 100.0 * rand.NextDouble();
            ir.PriceUpdate(randomKey, randPrice);
        }
    }
}
