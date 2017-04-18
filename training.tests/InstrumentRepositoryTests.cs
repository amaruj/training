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
            _repository = Substitute.For<IInstrumentRepository>();
        }

        [Test]
        public void TestThatItsNotPossibleToAddTwiceTheSameInstrument()
        {
            var instrument = new Instrument("Instrument1", InstrumentType.Bond);
            _repository.AddInstrument(instrument);
            Assert.Throws<InvalidOperationException>(() => _repository.AddInstrument(instrument));
        }

        [Test]
        public void TestGetInstrument()
        {
            var instrument = new Instrument("Instrument1", InstrumentType.Bond);
            _repository.AddInstrument(instrument);
            Assert.Equals(instrument, _repository.GetInstrument("Instrument1"));
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
