using System;

namespace training
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // Initialisation d'un repository 
            IInstrumentRepository repository = new MyInstrumentRepository();
            repository.InitWithPrices(10);
         
            var pricer = new Pricer(repository, 20);
            Console.WriteLine($"Moyenne des 5 derniers prix : {pricer.MeanPrices(5)}");
            while (Console.Read() != 'q')
            {
            }


        }
    }
}
