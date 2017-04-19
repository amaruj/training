using System;
namespace training
{
    public class Program
    {
        private static void Main(string[] args)
        {
            IInstrumentRepository _repository;
            Pricer _pricer;

            // Génrateur aléatoire 
            Random rand;
            rand = new Random((int)DateTime.Now.Ticks);

            // Initialisation d'un repository 
            _repository = new MyInstrumentRepository();
            _repository.Init();

            // Création d'un pricer 
            _pricer = new Pricer(_repository, 1000, rand);
            _pricer.price();
            
        }
    }
}
