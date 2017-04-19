using System;
using System.Linq;
using NUnit.Framework;
using System.Timers;

namespace training.tests
{
    [TestFixture]
    public class PricerTest
    {
        private IInstrumentRepository _repository;
        private Pricer _pricer;

        [SetUp]
        public void SetUp()
        {
            _repository = new MyInstrumentRepository();
            _repository.Init();
            Random rand = new Random((int)DateTime.Now.Ticks);
            _pricer = new Pricer(_repository,500,rand);
        }

        [Test]
        public void TestOnTimedEvent()
        {          
            _pricer.OnTimedEvent(new object(), new EventArgs() as ElapsedEventArgs);
            Assert.IsTrue(true);
        }
    }
}
