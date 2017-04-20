using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using NSubstitute;

namespace training.tests
{
    [TestFixture]
    public class PricerTest
    {
        private IInstrumentRepository _repository;
        private Pricer _pricer;

       
        [Test]
        public void TestPrice()
        {
            _repository = Substitute.For<IInstrumentRepository>();
            _repository.GetInstruments()
                .Returns(new List<Instrument>
                {
                    new Instrument("Toto", InstrumentType.Bond)
                });
            _pricer = new Pricer(_repository, 500);
            _pricer.Price();

            Thread.Sleep(800);
            
            _repository.Received(1).PriceUpdate("Toto", Arg.Any<double>());
        }

       

    }
}
