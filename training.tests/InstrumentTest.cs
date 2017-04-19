﻿using System;
using System.Linq;
using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

namespace training.tests
{
    class InstrumentTest
    {
        private Instrument _instrument;
        [SetUp]
        public void SetUp()
        {
            _instrument = new Instrument("Instrument", InstrumentType.Bond);           
        }

        [TestCase(1)]
        [TestCase(4)]
        [TestCase(10)]
        public void TestMeanPrices(int n)
        {
            for (int j = 0; j < n; j++)
            {
                _instrument.Prices.Push(j);
            }
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
            Assert.AreEqual(_instrument.ComputeMeanPrices(5), mean);

        }
    }
}
