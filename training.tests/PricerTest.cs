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

        [TestCase(1)]
        [TestCase(4)]
        [TestCase(10)]
        public void TestMeanPrices(int n)
        {
            _repository = new MyInstrumentRepository();
            _repository.InitWithPrices(n);
            _pricer = new Pricer(_repository, 500);
            double mean;
            switch (n)
            {
                case 1:
                    mean = 0.0;
                    break;
                case 4:
                    mean = 1.5;
                    break;
                default:
                    mean = 7.0;
                    break;
            }
            Assert.AreEqual(_pricer.MeanPrices(5),mean);            
        }

        [Test]
        public void TestMeanPricesWhenTheStackIsEmpty()
        {
            _repository = new MyInstrumentRepository();
            _repository.Init();
            _pricer = new Pricer(_repository, 500);         
            Assert.AreEqual(_pricer.MeanPrices(5), 0.0);
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void TestMeanPricesWithInvalidInput(int n)
        {
            _repository = new MyInstrumentRepository();
            _repository.Init();
            _pricer = new Pricer(_repository, 500);
            Assert.Throws<InvalidOperationException>(() => _pricer.MeanPrices(n) );
        }


    }
}
