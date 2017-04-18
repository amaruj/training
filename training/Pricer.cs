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
        Timer timer;
        IInstrumentRepository ir;

        public Pricer(IInstrumentRepository ir, double interval)
        {
            timer = new System.Timers.Timer(interval);
            this.ir = ir;
        }
        
        public void price()
        {
            Random rand = new Random();
            // Choix aléatoire d'un instrument dans le repository
            string randomKey = ir.getRandomInstrumentKey();
            double randPrice = rand.NextDouble();
            ir.PriceUpdate(randomKey,randPrice);
        }
    }
}
