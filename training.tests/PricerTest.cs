using System;
using System.Linq;
using NUnit.Framework;

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
            _pricer = new Pricer(_repository,500);
        }

        [Test]
        public void TestPrice()
        {
            _pricer.price();
            Assert.IsTrue(true);
        }
    }
}
