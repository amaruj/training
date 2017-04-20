using System;

namespace training
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // Initialisation d'un repository 
            IInstrumentRepository repository = new MyInstrumentRepository();
            repository.Init(10);
         
            var pricer = new Pricer(repository, 500);

            pricer.Price();
            while (Console.Read() != 'q')
            {
            }


        }
    }
}
