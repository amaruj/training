using System;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace training.tests
{
    [TestFixture]
    public class InstrumentRepositoryTests
    {
        private IInstrumentRepository _repository;

        [SetUp]
        public void SetUp()
        {
            //TODO : Replace by the Respository Implementation
            _repository = new MyInstrumentRepository();
        }

        [Test]
        public void TestThatItsNotPossibleToAddTwiceTheSameInstrument()
        {
            var instrument = new Instrument("Instrument1", InstrumentType.Bond);
            _repository.AddInstrument(instrument);
            Assert.Throws<InvalidOperationException>(() => _repository.AddInstrument(instrument));
        }

        [TestCase("Instrument1")]
        [TestCase("Instrument2")]
        public void TestGetInstrument(string instrumentName)
        {
            var instrument = new Instrument(instrumentName, InstrumentType.Bond);
            _repository.AddInstrument(instrument);

            Assert.AreEqual(instrument, _repository.GetInstrument(instrumentName));
        }
        
        [Test]
        public void TestThatGetInstrumentThrowsAnExceptionIfInstrumentDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => _repository.GetInstrument("InstrumentA"));
        }

        [Test]
        public void TestGetInstruments()
        {
            _repository.AddInstrument(new Instrument("Instrument1", InstrumentType.Bond));
            _repository.AddInstrument(new Instrument("Instrument2", InstrumentType.Forex));

            Assert.AreEqual(2, _repository.GetInstruments().Count());
        }

        [Test]
        public void TestInit()
        {
            _repository.Init();

            Assert.AreEqual(5000, _repository.GetInstruments().Count(instrument => instrument.Type == InstrumentType.Bond));
            Assert.AreEqual(5000, _repository.GetInstruments().Count(instrument => instrument.Type == InstrumentType.Forex));
        }
    }
}
